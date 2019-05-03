using OrderIn.Services.Items.Domain.Models;
using System.Threading.Tasks;

namespace OrderIn.Services.Items.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<xItem> GetAsync(string item);
        Task AddAsync(xItem item);
        Task UpdateAsync(xItem item);
    }
}
