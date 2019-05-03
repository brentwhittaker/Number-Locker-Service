using Microsoft.Extensions.Logging;
using OrderIn.Common.Commands;
using OrderIn.Common.Events;
using OrderIn.Common.Exceptions;
using OrderIn.Services.Worker.Domain.Services;
using RawRabbit;
using System;
using System.Threading.Tasks;

namespace OrderIn.Services.Worker.Handlers
{
    public class ItemCreatedHandler : IEventHandler<ItemCreated2>
    {
        private readonly IBusClient _busClient;
        private readonly IWorkerService _service;
        private readonly ILogger<ItemCreatedHandler> _logger;

        public ItemCreatedHandler(IBusClient busClient,
            IWorkerService service,
            ILogger<ItemCreatedHandler> logger)
        {
            _busClient = busClient;
            _service = service;
            _logger = logger;
        }
        public async Task HandleAsync(ItemCreated2 @event)
        {
            try
            {
                _logger.LogInformation($"Processing item: {@event.Item}");

                await _service.ProcessAsync(new Domain.Models.xItem(
                    @event.Id,
                    @event.Item,
                    @event.Status,
                    @event.Count));

                return;
            }
            catch (OrderInException ex)
            {
                await _busClient.PublishAsync(new ItemRejected(
                    @event.Id,
                    ex.Code,
                    ex.Message
                ));
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new ItemRejected(
                    @event.Id,
                    "error",
                    ex.Message
                ));
                _logger.LogError(ex.Message);
            }
        }
    }
}
