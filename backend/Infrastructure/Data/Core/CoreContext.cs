namespace Infrastructure.Data.Core;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

public class CoreContext : DbContext
{
    private readonly IHostEnvironment environment;
    private readonly IConfiguration configuration;

    public CoreContext(IHostEnvironment environment, IConfiguration configuration)
    {
        this.environment = environment;
        this.configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(this.configuration.GetConnectionString(Constants.ConnectionStringDefault), options =>
        {
            options.CommandTimeout(120);
        });

        if (this.environment.IsDevelopment())
        {
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
        }

        base.OnConfiguring(optionsBuilder);
    }
}