namespace Infrastructure.Settings;

public class ConnectionStringsSettings
{
    public const string ConnectionStrings = "ConnectionStrings";

    public string Default { get; set; } = string.Empty;
}
