namespace Api.Data.Context
{
    using Infrastructure.Extensions;
    using Infrastructure.Resources;
    using Mapping;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Hosting;

    public class CoreContext : DbContext
    {
        private readonly IHostEnvironment _environment;

        public CoreContext(IHostEnvironment environment)
        {
            _environment = environment;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PeopleMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Env.ConnectionString.GetEnv(), options =>
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