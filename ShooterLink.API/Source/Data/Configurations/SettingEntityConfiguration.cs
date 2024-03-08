using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShooterLink.API.Data.Configurations.Base;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Data.Configurations;

public class SettingEntityConfiguration : EntityConfiguration<Setting>
{
    public override void Configure(EntityTypeBuilder<Setting> builder)
    {
        base.Configure(builder);
    }
}