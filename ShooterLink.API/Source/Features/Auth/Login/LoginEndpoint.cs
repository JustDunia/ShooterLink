using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ShooterLink.API.Configuration;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Features.Auth.Login;

public class LoginEndpoint(
    IOptions<KeysOptions> options,
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

        var jwtToken = JwtBearer.CreateToken(
            o =>
            {
                o.SigningKey = options.Value.SigningKey;
                o.ExpireAt = DateTime.UtcNow.AddDays(1);
                o.User.Roles.Add([..userRoles]);
                o.User.Claims.Add(("UserName", req.Email));
                o.User["UserId"] = user.Id.ToString();
            });

        return TypedResults.Ok(new LoginResponse(
            FirstName: "Your",
            LastName: "Name",
            Token: jwtToken
        ));
    }
}