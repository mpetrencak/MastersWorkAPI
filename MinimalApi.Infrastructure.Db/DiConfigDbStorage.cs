using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Core.Infrastructure;
using MinimalApi.Infrastructure.Db.Repository;

namespace MinimalApi.Infrastructure.Db
{
    public static class DiConfigDbStorage
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MinimalApiDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IEventRepository, EventRepository>();

            services.AddAutoMapper(cfg => { cfg.AddExpressionMapping(); },
                AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
