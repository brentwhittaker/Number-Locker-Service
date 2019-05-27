using Hangfire;
using Hangfire.Mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Micro.Common.Events;
using Micro.Common.Mongo;
using Micro.Common.RabbitMq;
using Micro.Services.Worker.Domain.Services;
using Micro.Services.Worker.Handlers;
using Micro.Services.Worker.Services;

namespace Micro.Services.Worker
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
            services.AddScoped<IEventHandler<ItemCreated2>, ItemCreatedHandler>();
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddHangfire(config =>
            {
                var migrationOptions = new MongoStorageOptions
                {
                    MigrationOptions = new MongoMigrationOptions
                    {
                        Strategy = MongoMigrationStrategy.Migrate,
                        BackupStrategy = MongoBackupStrategy.Collections
                    }
                };
                config.UseColouredConsoleLogProvider(Hangfire.Logging.LogLevel.Info);
                config.UseMongoStorage(Configuration.GetSection("mongo:connectionString").Value, Configuration.GetSection("mongo:database").Value, migrationOptions);
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

            app.UseHangfireServer();
            app.UseHangfireDashboard();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
