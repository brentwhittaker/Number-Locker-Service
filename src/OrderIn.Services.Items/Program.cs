using Micro.Common.Commands;
using Micro.Common.Events;
using Micro.Common.RabbitMq;
using Micro.Common.Services;
using System.Threading.Tasks;

namespace Micro.Services.Items
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }
        public async static Task MainAsync(string[] args)
        {
            await ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<xItem>()
                .SubscribeToEvent<ItemStatusUpdated2>()
                .Build()
                .Run();
        }
    }
}
