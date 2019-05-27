using Microsoft.Extensions.Logging;
using Micro.Common.Commands;
using Micro.Common.Events;
using Micro.Common.Exceptions;
using Micro.Services.Items.Domain.Services;
using RawRabbit;
using RawRabbit.Configuration.Exchange;
using System;
using System.Threading.Tasks;

namespace Micro.Services.Items.Handlers
{
    public class UpsertItemHandler : ICommandHandler<xItem>
    {
        private readonly IBusClient _busClient;
        private readonly IItemService _service;
        private readonly ILogger<UpsertItemHandler> _logger;

        public UpsertItemHandler(IBusClient busClient,
            IItemService service,
            ILogger<UpsertItemHandler> logger)
        {
            _busClient = busClient;
            _service = service;
            _logger = logger;
        }
        public async Task HandleAsync(xItem command)
        {
            try
            {
                var xitem = await _service.GetAsync(command.Item);
                if (xitem == null)
                {
                    await InsertAsync(command);
                }
                else
                {
                    await UpdateAsync(command, xitem);
                }

                return;
            }
            catch (OrderInException ex)
            {
                await _busClient.PublishAsync(new ItemRejected(
                    command.Id,
                    ex.Code,
                    ex.Message
                ));
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new ItemRejected(
                    command.Id,
                    "error",
                    ex.Message
                ));
                _logger.LogError(ex.Message);
            }
        }

        private async Task UpdateAsync(xItem command, Domain.Models.xItem xitem)
        {
            _logger.LogInformation($"Updating item: {command.Item}");

            xitem = await _service.UpdateAsync(xitem);

            await _busClient.PublishAsync(new ItemCountUpdated(
                xitem.Id,
                xitem.Item,
                xitem.Status,
                xitem.Count
            ));
        }

        private async Task InsertAsync(xItem command)
        {
            _logger.LogInformation($"Creating item: {command.Item}");

            await _service.AddAsync(
                command.Id,
                command.Item,
                command.Status,
                command.Count
            );

            var xItem = await _service.GetAsync(command.Item);

            // NOTE: these two methods should be refactored into one using rabbitmq exchange with fanout, 
            // currently implemented only as rabbitmq direct msg queue
            await _busClient.PublishAsync(new ItemCreated1(
                xItem.Id,
                xItem.Item,
                xItem.Status,
                xItem.Count
            ));

            await _busClient.PublishAsync(new ItemCreated2(
                xItem.Id,
                xItem.Item,
                xItem.Status,
                xItem.Count
            ));
        }
    }
}
