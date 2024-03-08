using Microsoft.EntityFrameworkCore;
using ShooterLink.API.Data;

namespace ShooterLink.API.Configuration;

public static class DatabaseConfiguration
{
    public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(builder.Configuration
                .GetSection(nameof(DatabaseOptions))
                .GetValue<string>(nameof(DatabaseOptions.ConnectionString))));

        return builder;
    }

    public static WebApplication UseDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();

        var dbExists = context.Database.CanConnect();
        if (dbExists)
        {
            context.Database.Migrate();
        }
        else
        {
            context.Database.Migrate();
            var seeder = new InitialDataSeeder(app);
            seeder.SeedInitialData();
        }

        return app;
    }
}