namespace Api.Data.Context
{
    using Infrastructure.Extensions;
    using Infrastructure.Resources;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;

    public class CoreContext : DbContext
    {
        private readonly IHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public CoreContext(IHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString(Env.ConnectionStringsDefault), options =>
            {
                options.CommandTimeout(120);
            });

            if (_environment.IsDevelopment())
            {
                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.EnableSensitiveDataLogging();
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}