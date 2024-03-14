using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.Extensions.Options;
using ShooterLink.API.Configuration;

namespace ShooterLink.API.Auth.Register;

public class RegisterEndpoint(IOptions<KeysOptions> options) : Endpoint<RegisterRequest, RegisterResponse>
{
    public override void Configure()
    {
        Post("/api/auth/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
    {
        var jwtToken = JwtBearer.CreateToken(
            o =>
            {
                o.SigningKey = options.Value.SigningKey;
                o.ExpireAt = DateTime.UtcNow.AddDays(1);
                o.User.Claims.Add(("UserName", req.Email));
                o.User["UserId"] = "001"; //indexer based claim setting
            });

        await SendAsync(new(req.Email, jwtToken));
    }
}