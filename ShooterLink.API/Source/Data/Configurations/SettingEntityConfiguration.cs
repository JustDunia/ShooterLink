using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShooterLink.API.Data.Configurations.Base;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Data.Configurations;

public class SettingEntityConfiguration : EntityConfiguration<Setting>
{
    public override void Configure(EntityTypeBuilder<Setting> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.SettingName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.StringValue)
            .HasMaxLength(500);

        builder.Property(e => e.CreatorId)
            .IsRequired();

        builder.Property(e => e.ModifierId)
            .IsRequired();

        builder.Property(e => e.Created)
            .IsRequired()
            .HasColumnType("Timestamp")
            .HasDefaultValue(DateTime.Now);

        builder.Property(e => e.Modified)
            .IsRequired()
            .HasColumnType("Timestamp")
            .HasDefaultValue(DateTime.Now);
    }
}