using Microsoft.Extensions.Logging;
using Micro.Api.Models;
using Micro.Api.Repositories;
using Micro.Common.Events;
using System.Threading.Tasks;

namespace Micro.Api.Handlers
{
    public class ItemStatusUpdatedHandler : IEventHandler<ItemStatusUpdated1>
    {
        private readonly IItemRepository _repository;
        private readonly ILogger<ItemStatusUpdatedHandler> _logger;

        public ItemStatusUpdatedHandler(IItemRepository repository, ILogger<ItemStatusUpdatedHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task HandleAsync(ItemStatusUpdated1 @event)
        {
            await _repository.UpdateAsync(new xItem
            {
                Id = @event.Id,
                Item = @event.Item,
                Status = @event.Status,
                Count = @event.Count
            });
            _logger.LogInformation($"Item updated: {@event.Item}");
        }
    }
}
