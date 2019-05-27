using Microsoft.Extensions.Logging;
using Micro.Common.Events;
using Micro.Services.Items.Domain.Models;
using Micro.Services.Items.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro.Services.Items.Handlers
{
    public class ItemStatusUpdatedHandler : IEventHandler<ItemStatusUpdated2>
    {
        private readonly IItemRepository _repository;
        private readonly ILogger<ItemStatusUpdatedHandler> _logger;

        public ItemStatusUpdatedHandler(IItemRepository repository, ILogger<ItemStatusUpdatedHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task HandleAsync(ItemStatusUpdated2 @event)
        {
            await _repository.UpdateAsync(new xItem(
                @event.Id,
                @event.Item,
                @event.Status,
                @event.Count));

            _logger.LogInformation($"Item updated: {@event.Item}");
        }
    }
}
