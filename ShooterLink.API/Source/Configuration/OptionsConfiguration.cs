namespace ShooterLink.API.Configuration;

public static class OptionsConfiguration
{
    /// <summary>
    /// Binds settings from appsettings.json to configuration objects implementing options pattern.
    /// Add new objects from appsettins.json as needed.
    /// </summary>
    /// <param name="builder"></param>
    public static WebApplicationBuilder BindOptions(this WebApplicationBuilder builder)
    {
        builder.Services.AddOptions<DatabaseOptions>()
            .Bind(builder.Configuration.GetRequiredSection(nameof(DatabaseOptions)));

        builder.Services.AddOptions<KeysOptions>()
            .Bind(builder.Configuration.GetRequiredSection(nameof(KeysOptions)));

        builder.Services.AddOptions<EmailOptions>()
            .Bind(builder.Configuration.GetRequiredSection(nameof(EmailOptions)));

        return builder;
    }
}

public sealed class DatabaseOptions
{
    public required string ConnectionString { get; set; }
}

public sealed class KeysOptions
{
    public required string SigningKey { get; set; }
}

public sealed class EmailOptions
{
    public required string Host { get; set; }
    public int Port { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string SenderAddress { get; set; }
}