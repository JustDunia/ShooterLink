using ShooterLink.API.Data.Entities.Base;

namespace ShooterLink.API.Data.Entities;

public sealed class User : Entity
{
    public required string PasswordHash { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string NormalizedEmail { get; set; }
    public bool EmailConfirmed { get; set; }
    public string? NickName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public bool Verified { get; set; }
    public string? Token { get; set; }
    public DateTime Crated { get; set; }
    public ICollection<Role> Roles { get; set; } = [];
}