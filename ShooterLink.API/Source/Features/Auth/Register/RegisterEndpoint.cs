using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using ShooterLink.API.Data.Entities;
using ShooterLink.API.Features.Auth;

namespace ShooterLink.API.Auth.Register;

public class RegisterEndpoint(
    ITokenCreator tokenCreator,
    IAuthService service,
    IPasswordHasher<User> passwordHasher)
    : Endpoint<RegisterRequest,
        Results<Created,
            ProblemDetails>>
{
    public override void Configure()
    {
        Post("/api/auth/register");
        AllowAnonymous();
    }

    public override async Task<Results<Created, ProblemDetails>> ExecuteAsync(RegisterRequest req,
        CancellationToken ct)
    {
        var user = await service.GetUserByEmail(req.Email);

        if (user is not null)
        {
            AddError("User with this email address already exists");
            return new ProblemDetails(ValidationFailures);
        }

        user = new User()
        {
            FirstName = req.FirstName,
            LastName = req.LastName,
            Email = req.Email,
            NormalizedEmail = req.Email.ToUpper(),
            Created = DateTime.Now
        };

        var passwordHash = passwordHasher.HashPassword(user, req.Password);
        user.PasswordHash = passwordHash;

        try
        {
            await service.CreateUser(user);
        }
        catch (Exception ex)
        {
            AddError(ex.Message);
            return new ProblemDetails(ValidationFailures);
        }

        return TypedResults.Created();
    }
}