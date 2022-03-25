namespace Infrastructure.Settings;

public class ElasticConfigurationSettings
{
    public const string ElasticConfiguration = "ElasticConfiguration";

    public string Uri { get; set; } = string.Empty;

    public string User { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}