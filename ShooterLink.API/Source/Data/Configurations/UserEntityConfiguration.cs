using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShooterLink.API.Data.Configurations.Base;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Data.Configurations;

public class UserEntityConfiguration : EntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.FirstName)
            .HasMaxLength(255);

        builder.Property(e => e.LastName)
            .HasMaxLength(255);

        builder.Property(e => e.Email)
            .HasMaxLength(255);

        builder.Property(e => e.NormalizedEmail)
            .HasMaxLength(255);

        builder.Property(e => e.NickName)
            .HasMaxLength(255);

        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(e => e.Token)
            .HasMaxLength(255);

        builder.Property(e => e.Crated)
            .HasColumnType("Timestamp")
            .HasDefaultValue(DateTime.Now);

        builder.HasMany(e => e.Roles)
            .WithMany(e => e.Users);
    }
}