using OrderIn.Common.Events;
using OrderIn.Common.RabbitMq;
using OrderIn.Common.Services;
using System.Threading.Tasks;

namespace OrderIn.Services.Worker
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
                .SubscribeToEvent<ItemCreated2>()
                .Build()
                .Run();
        }
    }
}
