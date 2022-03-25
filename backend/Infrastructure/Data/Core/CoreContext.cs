namespace Infrastructure.Data.Core;

using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

public class CoreContext : DbContext
{
    private readonly IHostEnvironment environment;
    private readonly ConnectionStringsSettings connectionStrings;

    public CoreContext(IHostEnvironment environment, ConnectionStringsSettings connectionStrings)
    {
        this.environment = environment;
        this.connectionStrings = connectionStrings;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(this.connectionStrings.Default, options =>
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