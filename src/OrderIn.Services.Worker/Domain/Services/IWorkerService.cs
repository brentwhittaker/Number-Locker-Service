using OrderIn.Services.Worker.Domain.Models;
using System.Threading.Tasks;

namespace OrderIn.Services.Worker.Domain.Services
{
    public interface IWorkerService
    {
        Task ProcessAsync(xItem item);
    }
}
