using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderIn.Common.Commands;
using OrderIn.Common.Events;
using OrderIn.Common.Mongo;
using OrderIn.Common.RabbitMq;
using OrderIn.Services.Items.Domain.Repositories;
using OrderIn.Services.Items.Domain.Services;
using OrderIn.Services.Items.Handlers;
using OrderIn.Services.Items.Repositories;
using OrderIn.Services.Items.Services;

namespace OrderIn.Services.Items
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMongoDb(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddScoped<ICommandHandler<xItem>, UpsertItemHandler>();
            services.AddScoped<IEventHandler<ItemStatusUpdated2>, ItemStatusUpdatedHandler>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemService, ItemService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
