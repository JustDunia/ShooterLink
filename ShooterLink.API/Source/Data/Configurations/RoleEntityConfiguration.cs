using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShooterLink.API.Data.Configurations.Base;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Data.Configurations;

public class RoleEntityConfiguration : EntityConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Name)
            .HasMaxLength(20);

        builder.HasMany(e => e.Users)
            .WithMany(e => e.Roles);

        builder.HasData([
            new { Id = Guid.NewGuid(), Name = "Admin" },
            new { Id = Guid.NewGuid(), Name = "Athlete" },
            new { Id = Guid.NewGuid(), Name = "Coach" },
            new { Id = Guid.NewGuid(), Name = "Office" },
            new { Id = Guid.NewGuid(), Name = "Guest" },
        ]);
    }
}