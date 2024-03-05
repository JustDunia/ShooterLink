namespace ShooterLink.API.Configuration;

public sealed class DatabaseOptions
{
    public required string Host { get; set; }
    public required int Port { get; set; }
    public required string Name { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public sealed class SecurityOptions
{
    public required string SigningKey { get; set; }
}