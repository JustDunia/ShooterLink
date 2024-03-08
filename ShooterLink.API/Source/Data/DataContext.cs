using Microsoft.EntityFrameworkCore;
using ShooterLink.API.Data.Configurations;
using ShooterLink.API.Data.Entities;

namespace ShooterLink.API.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public required DbSet<User> Users { get; init; }
    public required DbSet<Role> Roles { get; init; }
    public required DbSet<Setting> Settings { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        new RoleEntityConfiguration().Configure(builder.Entity<Role>());
        new SettingEntityConfiguration().Configure(builder.Entity<Setting>());
        new UserEntityConfiguration().Configure(builder.Entity<User>());
    }
}