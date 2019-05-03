using Microsoft.Extensions.Logging;
using OrderIn.Api.Models;
using OrderIn.Api.Repositories;
using OrderIn.Common.Events;
using System.Threading.Tasks;

namespace OrderIn.Api.Handlers
{
    public class ItemCountUpdatedHandler : IEventHandler<ItemCountUpdated>
    {
        private readonly IItemRepository _repository;
        private readonly ILogger<ItemCountUpdatedHandler> _logger;

        public ItemCountUpdatedHandler(IItemRepository repository, ILogger<ItemCountUpdatedHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task HandleAsync(ItemCountUpdated @event)
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
