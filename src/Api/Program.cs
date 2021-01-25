using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using System;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Console()
                    .CreateLogger();
                    
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .CaptureStartupErrors(true)
                    .UseSerilog((context, loggerConfiguration) =>
                    {
                        loggerConfiguration
                            .ReadFrom.Configuration(context.Configuration)
                            .Enrich.WithProperty("ApplicationName", typeof(Program).Assembly.GetName().Name)
                            .Enrich.WithProperty("Environment", context.HostingEnvironment);
                    });
                });
    }
}
