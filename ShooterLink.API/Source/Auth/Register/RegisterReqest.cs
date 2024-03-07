namespace ShooterLink.API.Auth.Register;

public record RegisterRequest(
    string Email,
    string Password);