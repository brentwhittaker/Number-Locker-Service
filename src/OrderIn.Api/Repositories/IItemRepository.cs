using OrderIn.Api.Models;
using System.Threading.Tasks;

namespace OrderIn.Api.Repositories
{
    public interface IItemRepository
    {
        Task<xItem> GetAsync(string item);
        Task AddAsync(xItem item);
        Task UpdateAsync(xItem item);
    }
}
