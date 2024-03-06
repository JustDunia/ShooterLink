using ShooterLink.API.Configuration;
using ShooterLink.API.Data.Database;

var builder = WebApplication.CreateBuilder(args);

builder.BindOptions();

builder.Services.ConfigureServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
