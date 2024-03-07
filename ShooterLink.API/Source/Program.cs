using FastEndpoints;
using ShooterLink.API.Configuration;
using ShooterLink.API.Data.Database;

var builder = WebApplication.CreateBuilder(args);

builder.BindOptions();
builder.ConfigureEndpoints();

builder.Services.ConfigureServices();

var app = builder.Build();

app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapFallbackToFile("/index.html");

DatabaseInitializer.Initialize(app);

app.Run();