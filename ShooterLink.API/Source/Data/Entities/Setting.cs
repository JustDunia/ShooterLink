using ShooterLink.API.Data.Entities.Base;

namespace ShooterLink.API.Data.Entities;

public sealed class Setting : Entity
{
    public required string SettingName { get; set; }
    public string? StringValue { get; set; }
    public bool? BoolValue { get; set; }
    public DateTime DateValue { get; set; }
    public int? IntValue { get; set; }
    public double? DoubleValue { get; set; }
    public Guid Creator { get; set; }
    public Guid Modifier { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}