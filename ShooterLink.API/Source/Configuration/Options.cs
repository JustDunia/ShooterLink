namespace ShooterLink.API.Configuration;

public sealed class DatabaseOptions
{
    public required string ConnectionString { get; set; }
}

public sealed class KeysOptions
{
    public required string SigningKey { get; set; }
}