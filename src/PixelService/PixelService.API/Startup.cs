using PixelService.Application;
using PixelService.Domain.Interfaces;
using PixelService.Infrastructure;

namespace PixelService.API
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
            // Configure RabbitMQ settings
            services.Configure<RabbitMQSettings>(Configuration.GetSection("RabbitMQ"));

            // Register application services
            services.AddScoped<IPixelAppService, PixelAppService>();

            // Register domain services
            services.AddScoped<IStorageService, StorageService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}