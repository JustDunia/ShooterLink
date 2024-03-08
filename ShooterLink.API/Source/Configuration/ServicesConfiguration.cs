using Microsoft.AspNetCore.Identity;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Configuration;

public static class ServicesConfiguration
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        // Auth
        builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

        return builder;
    }
}