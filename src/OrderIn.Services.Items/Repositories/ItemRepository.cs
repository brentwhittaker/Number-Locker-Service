using MongoDB.Driver;
using MongoDB.Driver.Linq;
using OrderIn.Services.Items.Domain.Models;
using OrderIn.Services.Items.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace OrderIn.Services.Items.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IMongoDatabase _database;

        public ItemRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task AddAsync(xItem item)
            => await Collection.InsertOneAsync(item);

        public async Task<xItem> GetAsync(string item)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Item == item);

        public async Task UpdateAsync(xItem item)
            => await Collection.UpdateOneAsync(
                Builders<xItem>.Filter.Eq(s => s.Id, item.Id), 
                Builders<xItem>.Update
                    .Set("Count", item.Count)
                    .Set("Status", item.Status));

        private IMongoCollection<xItem> Collection
            => _database.GetCollection<xItem>("Items");
    }
}
