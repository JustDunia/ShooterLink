using ShooterLink.API.Data.Entities.Base;

namespace ShooterLink.API.Data.Entities;

public sealed class User : Entity
{
    public string PasswordHash { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string NormalizedEmail { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public string? NickName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public bool Verified { get; set; }
    public string? Token { get; set; } // TODO rename to verificationToken
    public DateTime Created { get; set; }

    public ICollection<Role> Roles { get; set; } = [];
    public ICollection<Setting> CreatedSettings { get; set; } = [];
    public ICollection<Setting> ModifiedSettings { get; set; } = [];
}