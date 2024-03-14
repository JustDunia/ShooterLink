using FastEndpoints.Security;
using Microsoft.Extensions.Options;
using ShooterLink.API.Configuration;

namespace ShooterLink.API.Features.Auth;

public interface ITokenCreator
{
    string CreateToken(string userName, string userId, List<string> userRoles);
}

public class TokenCreator(IOptions<KeysOptions> options) : ITokenCreator
{
    public string CreateToken(string userName, string userId, List<string> userRoles)
    {
        return JwtBearer.CreateToken(
            o =>
            {
                o.SigningKey = options.Value.SigningKey;
                o.ExpireAt = DateTime.UtcNow.AddDays(1);
                o.User.Roles.Add([..userRoles]);
                o.User.Claims.Add(("UserName", userName));
                o.User["UserId"] = userId;
            });
    }
}