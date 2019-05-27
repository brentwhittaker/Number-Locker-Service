﻿using Micro.Common.Events;
using Micro.Common.RabbitMq;
using Micro.Common.Services;
using System.Threading.Tasks;

namespace Micro.Services.Worker
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
