using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.Extensions.Options;
using ShooterLink.API.Configuration;

namespace ShooterLink.API.Auth.Login;

public class LoginEndpoint(IOptions<KeysOptions> options) : Endpoint<LoginRequest, LoginResponse>
{
    public override void Configure()
    {
        Post("api/auth/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        // logika sprawdzenia prawidłowości danych i pobrania danych użytkownika

        var jwtToken = JwtBearer.CreateToken(
            o =>
            {
                o.SigningKey = options.Value.SigningKey;
                o.ExpireAt = DateTime.UtcNow.AddDays(1);
                o.User.Claims.Add(("UserName", req.Email));
                o.User["UserId"] = "001"; //indexer based claim setting
            });

        await SendAsync(new(
            FirstName: "Your",
            LastName: "Name",
            Token: jwtToken
        ));
    }
}