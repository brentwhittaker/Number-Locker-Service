using Micro.Api.Models;
using System.Threading.Tasks;

namespace Micro.Api.Repositories
{
    public interface IItemRepository
    {
        Task<xItem> GetAsync(string item);
        Task AddAsync(xItem item);
        Task UpdateAsync(xItem item);
    }
}
