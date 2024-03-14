using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Features.Auth.Login;

public class LoginEndpoint(
    ITokenCreator tokenCreator,
    IAuthService service,
    IPasswordHasher<User> passwordHasher)
    : Endpoint<LoginRequest,
        Results<Ok<LoginResponse>,
            NotFound,
            ProblemDetails>>
{
    public override void Configure()
    {
        Post("api/auth/login");
        AllowAnonymous();
    }

    public override async Task<Results<Ok<LoginResponse>, NotFound, ProblemDetails>> ExecuteAsync(LoginRequest req,
        CancellationToken ct)
    {
        var user = await service.GetUserByEmail(req.Email);

        if (user is null)
        {
            return TypedResults.NotFound();
        }

        var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, req.Password);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            AddError("Invalid password");
            return new ProblemDetails(ValidationFailures);
        }

        var userRoles = user.Roles.Select(e => e.Name).ToList();

        var jwtToken = tokenCreator.CreateToken(req.Email, user.Id.ToString(), userRoles);

        return TypedResults.Ok(new LoginResponse(
            FirstName: "Your",
            LastName: "Name",
            Token: jwtToken
        ));
    }
}