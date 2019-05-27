using Hangfire;
using Microsoft.Extensions.Logging;
using Micro.Common.Events;
using Micro.Services.Worker.Domain.Models;
using Micro.Services.Worker.Domain.Services;
using RawRabbit;
using System;
using System.Threading.Tasks;

namespace Micro.Services.Worker.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IBusClient _busClient;
        private readonly ILogger<WorkerService> _logger;

        public WorkerService(IBusClient busClient, ILogger<WorkerService> logger)
        {
            _busClient = busClient;
            _logger = logger;
        }

        public void DoWork(xItem item)
        {
            _logger.LogInformation($"Item worked: item {item.Item}");

            item.UpdateStatus("locked");

            //NOTE: these two methods should be refactored into one using rabbitmq exchange with fanout,
            //currently implemented only as rabbitmq direct msg queue
            _busClient.PublishAsync(new ItemStatusUpdated1(
                    item.Id,
                    item.Item,
                    item.Status,
                    item.Count
                ));
            _busClient.PublishAsync(new ItemStatusUpdated2(
                    item.Id,
                    item.Item,
                    item.Status,
                    item.Count
                ));

        }

        public async Task ProcessAsync(xItem item)
        {
            BackgroundJob.Schedule(() =>
                DoWork(item),
            TimeSpan.FromMinutes(1));
        }
    }
}
