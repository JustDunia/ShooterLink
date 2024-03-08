using ShooterLink.API.Data.Entities.Base;

namespace ShooterLink.API.Data.Entities;

public sealed class Role : Entity
{
    public required string Name { get; set; }

    public ICollection<User> Users { get; set; } = [];
}