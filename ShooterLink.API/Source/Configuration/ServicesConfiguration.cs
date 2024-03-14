using Microsoft.AspNetCore.Identity;
using ShooterLink.API.Data.Entities;
using ShooterLink.API.Features.Auth;

namespace ShooterLink.API.Configuration;

public static class ServicesConfiguration
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        // Auth
        builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
        builder.Services.AddSingleton<ITokenCreator, TokenCreator>();
        builder.Services.AddScoped<IAuthService, AuthService>();

        return builder;
    }
}