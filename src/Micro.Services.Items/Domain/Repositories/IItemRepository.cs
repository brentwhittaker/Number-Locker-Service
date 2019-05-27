using Micro.Services.Items.Domain.Models;
using System.Threading.Tasks;

namespace Micro.Services.Items.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<xItem> GetAsync(string item);
        Task AddAsync(xItem item);
        Task UpdateAsync(xItem item);
    }
}
