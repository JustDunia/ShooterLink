using FastEndpoints;
using Serilog;
using ShooterLink.API.Configuration;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application");
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();


    builder.BindOptions()
        .ConfigureDatabase()
        .ConfigureEndpoints()
        .ConfigureServices();

    var app = builder.Build();

    app.UseDatabase();

    app.UseAuthentication()
        .UseAuthorization()
        .UseFastEndpoints();

    app.UseDefaultFiles()
        .UseStaticFiles();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapFallbackToFile("/index.html");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}