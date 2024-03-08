using Microsoft.AspNetCore.Identity;
using ShooterLink.API.Common;
using ShooterLink.API.Data;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Configuration;

public class InitialDataSeeder
{
    private readonly IConfiguration _config;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly DataContext _context;

    public InitialDataSeeder(WebApplication app)
    {
        var scope = app.Services.CreateScope();
        _passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher<User>>();
        _config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        _context = scope.ServiceProvider.GetRequiredService<DataContext>();
    }

    public void SeedInitialData()
    {
        var adminId = CreateAdminUser();
        AddClubSettings(adminId);
        _context.SaveChanges();
    }

    private Guid CreateAdminUser()
    {
        var adminRole = _context.Roles.Single(e => e.Name == "Admin");

        var admin = _config.GetSection("AdminUser").Get<User>()
                    ?? throw new ArgumentException("No admin user data provided");

        var hashedPassword = _passwordHasher.HashPassword(admin, admin.PasswordHash);

        admin.PasswordHash = hashedPassword;
        admin.Created = new DateTime(2020, 01, 01);
        admin.Verified = true;
        admin.EmailConfirmed = true;
        admin.NormalizedEmail = admin.Email.ToUpper();
        admin.Roles.Add(adminRole);

        _context.Users.Add(admin);
        return admin.Id;
    }

    private void AddClubSettings(Guid adminId)
    {
        var clubData = _config.GetSection("ClubData").GetChildren();
        var clubNameSection = clubData.FirstOrDefault(e => e.Key == "Name")
                              ?? throw new ArgumentException("No club name provided");

        var setting = new Setting()
        {
            SettingName = Constants.ClubName,
            StringValue = clubNameSection.Value,
            CreatorId = adminId,
            ModifierId = adminId
        };

        _context.Settings.Add(setting);
    }
}