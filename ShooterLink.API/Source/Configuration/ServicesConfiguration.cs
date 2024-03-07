using Microsoft.AspNetCore.Identity;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        // Auth
        services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();


        return services;
    }
}