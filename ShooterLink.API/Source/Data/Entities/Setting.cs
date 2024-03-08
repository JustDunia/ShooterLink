using ShooterLink.API.Data.Entities.Base;

namespace ShooterLink.API.Data.Entities;

public sealed class Setting : Entity
{
    public string SettingName { get; set; } = string.Empty;
    public string? StringValue { get; set; }
    public bool? BoolValue { get; set; }
    public DateTime? DateValue { get; set; }
    public int? IntValue { get; set; }
    public double? DoubleValue { get; set; }
    public Guid CreatorId { get; set; }
    public User? Creator { get; set; }
    public Guid ModifierId { get; set; }
    public User? Modifier { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}