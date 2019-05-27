using Micro.Services.Worker.Domain.Models;
using System.Threading.Tasks;

namespace Micro.Services.Worker.Domain.Services
{
    public interface IWorkerService
    {
        Task ProcessAsync(xItem item);
    }
}
