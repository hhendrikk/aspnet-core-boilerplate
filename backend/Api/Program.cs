namespace Api;

using System;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            CreateHostBuilder(args)
            .UseSerilog((context, service, loggerConfiguration) =>
            {
                var generalSettings = service.GetRequiredService<GeneralSettings>();
                var elasticConfiguration = service.GetService<ElasticConfigurationSettings>();

                loggerConfiguration
                    .Enrich.WithProperty(nameof(GeneralSettings.ApplicationName), generalSettings.ApplicationName)
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .ReadFrom.Configuration(context.Configuration);

                if (elasticConfiguration != null)
                {
                    loggerConfiguration
                        .WriteTo.Elasticsearch(ConfigureElasticSink(elasticConfiguration, generalSettings, context.HostingEnvironment.EnvironmentName));
                }
            })
            .Build()
            .Run();
        }
        catch (Exception ex)
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

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .UseStartup<Startup>()
                    .CaptureStartupErrors(true);
            });

    private static ElasticsearchSinkOptions ConfigureElasticSink(ElasticConfigurationSettings elasticConfiguration, GeneralSettings generalSettings, string environment)
    {
        return new ElasticsearchSinkOptions(new Uri(elasticConfiguration.Uri))
        {
            AutoRegisterTemplate = true,
            ModifyConnectionSettings = x => x
                .BasicAuthentication(elasticConfiguration.User, elasticConfiguration.Password)
                .ServerCertificateValidationCallback((o, certificate, arg3, arg4) => { return true; }),
            IndexFormat = $"{generalSettings.ApplicationName.ToLowerInvariant()}-{environment?.ToLowerInvariant()}"
        };
    }
}