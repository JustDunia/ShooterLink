namespace ShooterLink.API.Auth.Login;

public record LoginResponse(
    string FirstName,
    string LastName,
    string Token);