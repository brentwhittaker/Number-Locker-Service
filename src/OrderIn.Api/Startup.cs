using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderIn.Api.Handlers;
using OrderIn.Api.Repositories;
using OrderIn.Common.Events;
using OrderIn.Common.Mongo;
using OrderIn.Common.RabbitMq;
using Swashbuckle.AspNetCore.Swagger;

namespace OrderIn.Api
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
            services.AddLogging();
            services.AddMongoDb(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddScoped<IEventHandler<ItemCreated1>, ItemCreatedHandler>();
            services.AddScoped<IEventHandler<ItemCountUpdated>, ItemCountUpdatedHandler>();
            services.AddScoped<IEventHandler<ItemStatusUpdated1>, ItemStatusUpdatedHandler>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Number-Locker Api v1", Version = "v1" });
            });
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Number-Locker Api v1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
