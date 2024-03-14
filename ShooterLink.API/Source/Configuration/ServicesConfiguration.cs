using Microsoft.AspNetCore.Identity;
using ShooterLink.API.Data.Entities;
using ShooterLink.API.Features.Auth;

namespace ShooterLink.API.Configuration;

public static class ServicesConfiguration
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        // External service
        builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

        // Features
        builder.Services.AddScoped<IAuthService, AuthService>();

        return builder;
    }
}