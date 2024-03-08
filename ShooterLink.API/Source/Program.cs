using FastEndpoints;
using ShooterLink.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

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