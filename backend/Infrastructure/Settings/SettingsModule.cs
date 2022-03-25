namespace Infrastructure.Settings;

using Autofac;
using Microsoft.Extensions.Configuration;

public class SettingsModule : Module
{
    private readonly IConfiguration configuration;

    public SettingsModule(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
        var generalSettings = this.configuration.Get<GeneralSettings>();
        var elasticConfigurationSettings = this.configuration.GetSection(ElasticConfigurationSettings.ElasticConfiguration).Get<ElasticConfigurationSettings>();
        var connectionStrings = this.configuration.GetSection(ConnectionStringsSettings.ConnectionStrings).Get<ConnectionStringsSettings>();

        builder.RegisterInstance(generalSettings).SingleInstance();
        builder.RegisterInstance(connectionStrings).SingleInstance();

        if (elasticConfigurationSettings != null)
        {
            builder.RegisterInstance(elasticConfigurationSettings).SingleInstance();
        }
    }
}
