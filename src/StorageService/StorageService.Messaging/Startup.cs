using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StorageService.Application;
using StorageService.Domain.Interfaces;
using StorageService.Infrastructure;
using StorageService.Messaging.Options;

namespace StorageService.Messaging
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RabbitMQOptions>(Configuration.GetSection("RabbitMQ"));
            services.Configure<FileEventOptions>(Configuration.GetSection("File"));
            services.AddHostedService<RabbitMQConsumer>();

            // Register application services
            services.AddScoped<IFileEventRepository, FileEventRepository>();

            // Register domain services
            services.AddScoped<IStorageServiceApplication, StorageServiceApplication>();

        }
    }
}