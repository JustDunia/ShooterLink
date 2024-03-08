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
            .IsRequired()
            .HasMaxLength(20);

        builder.HasMany(e => e.Users)
            .WithMany(e => e.Roles);

        builder.HasData([
            new { Id = new Guid("1ca61828-4c2b-4af5-b551-498f97b864b7"), Name = "Admin" },
            new { Id = new Guid("6239f1d1-6dae-40c0-bf45-9ff9fd75216f"), Name = "Athlete" },
            new { Id = new Guid("b1106934-acd5-4000-a4e3-0b789d28f494"), Name = "Coach" },
            new { Id = new Guid("d7309100-d517-403c-8584-b005a406847d"), Name = "Office" },
            new { Id = new Guid("e5e88f2c-953c-4fe2-862e-0e5ff74242fd"), Name = "Guest" },
        ]);
    }
}