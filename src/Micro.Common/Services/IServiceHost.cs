using System.Threading.Tasks;

namespace Micro.Common.Services
{
    public interface IServiceHost
    {
        Task Run();
    }
}