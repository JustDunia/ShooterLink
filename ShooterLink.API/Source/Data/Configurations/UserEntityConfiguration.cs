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

        builder.Property(e => e.PasswordHash)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.NormalizedEmail)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.NickName)
            .HasMaxLength(255);

        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(e => e.Token)
            .HasMaxLength(500);

        builder.Property(e => e.Created)
            .IsRequired()
            .HasColumnType("Timestamp")
            .HasDefaultValue(DateTime.Now);

        builder.HasMany(e => e.Roles)
            .WithMany(e => e.Users);

        builder.HasMany(e => e.CreatedSettings)
            .WithOne(e => e.Creator)
            .HasForeignKey(e => e.CreatorId);

        builder.HasMany(e => e.ModifiedSettings)
            .WithOne(e => e.Modifier)
            .HasForeignKey(e => e.ModifierId);
    }
}