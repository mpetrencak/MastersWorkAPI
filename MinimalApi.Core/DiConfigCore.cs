using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Core.Services.Event;

namespace MinimalApi.Core
{
    public class DiConfigCore
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEventService, EventService>();
        }
    }
}
