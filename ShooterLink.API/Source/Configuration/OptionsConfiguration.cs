﻿namespace ShooterLink.API.Configuration;

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
            .Bind(builder.Configuration.GetSection(nameof(DatabaseOptions)));

        builder.Services.AddOptions<KeysOptions>()
            .Bind(builder.Configuration.GetSection(nameof(KeysOptions)));

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