using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Features.Auth.Login;

public class LoginEndpoint(
    ITokenCreator tokenCreator,
    IAuthService service,
    IPasswordHasher<User> passwordHasher)
    : Endpoint<LoginRequest, LoginResponse>
{
    public override void Configure()
    {
        Post("api/auth/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var user = await service.GetUserByEmail(req.Email);

        if (user is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        if (!user.EmailConfirmed)
        {
            ThrowError("Email not confirmed.");
        }

        if (!user.Verified)
        {
            ThrowError("User not verified by administrator");
        }

        var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, req.Password);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            ThrowError("Invalid password");
        }

        var userRoles = user.Roles.Select(e => e.Name).ToList();

        var jwtToken = tokenCreator.CreateToken(req.Email, user.Id.ToString(), userRoles);

        await SendAsync(new LoginResponse(
            FirstName: user.FirstName,
            LastName: user.LastName,
            Token: jwtToken,
            Roles: userRoles
        ));
    }
}