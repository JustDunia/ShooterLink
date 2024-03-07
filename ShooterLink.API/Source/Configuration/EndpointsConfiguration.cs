using FastEndpoints;
using FastEndpoints.Security;

namespace ShooterLink.API.Configuration;

public static class EndpointsConfiguration
{
    public static WebApplicationBuilder ConfigureEndpoints(this WebApplicationBuilder builder)
    {
        var signingKey = builder
            .Configuration
            .GetSection(nameof(KeysOptions))
            .GetValue<string>(nameof(KeysOptions.SigningKey));

        builder.Services.AddAuthenticationJwtBearer(s => s.SigningKey = signingKey)
            .AddAuthorization()
            .AddFastEndpoints();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }
}