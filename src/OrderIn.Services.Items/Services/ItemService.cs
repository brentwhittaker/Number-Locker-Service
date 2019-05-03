using OrderIn.Services.Items.Domain.Models;
using OrderIn.Services.Items.Domain.Repositories;
using OrderIn.Services.Items.Domain.Services;
using System;
using System.Threading.Tasks;

namespace OrderIn.Services.Items.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Guid id, string item, string status, int count)
        {
            var xItem = new xItem(id, item, "open", 1);
            await _repository.AddAsync(xItem);
        }

        public async Task<xItem> GetAsync(string item)
            => await _repository.GetAsync(item);

        public async Task<xItem> UpdateAsync(xItem item)
        {
            item.IncrementCount();
            await _repository.UpdateAsync(item);
            return item;
        }
    }
}
