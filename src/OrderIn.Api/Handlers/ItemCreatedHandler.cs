using Microsoft.Extensions.Logging;
using Micro.Api.Models;
using Micro.Api.Repositories;
using Micro.Common.Events;
using System.Threading.Tasks;

namespace Micro.Api.Handlers
{
    public class ItemCreatedHandler : IEventHandler<ItemCreated1>
    {
        private readonly IItemRepository _repository;
        private readonly ILogger<ItemCreatedHandler> _logger;

        public ItemCreatedHandler(IItemRepository repository, ILogger<ItemCreatedHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task HandleAsync(ItemCreated1 @event)
        {
            await _repository.AddAsync(new xItem
            {
                Id = @event.Id,
                Item = @event.Item,
                Status = @event.Status,
                Count = @event.Count
            });
            _logger.LogInformation($"Item created: {@event.Item}");
        }
    }
}
