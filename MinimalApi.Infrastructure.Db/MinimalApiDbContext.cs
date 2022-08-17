using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MinimalApi.Infrastructure.Db.DatabaseObjects;

namespace MinimalApi.Infrastructure.Db
{
    public class MinimalApiDbContext : DbContext
    {
        private readonly ILogger<MinimalApiDbContext> _logger;

        public MinimalApiDbContext(DbContextOptions options, ILogger<MinimalApiDbContext> logger) : base(options)
        {
            _logger = logger;
        }
        public DbSet<EventDo> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
