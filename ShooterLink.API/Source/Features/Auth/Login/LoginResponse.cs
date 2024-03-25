namespace ShooterLink.API.Features.Auth.Login;

public record LoginResponse(
    string FirstName,
    string LastName,
    string Token,
    List<string> Roles);