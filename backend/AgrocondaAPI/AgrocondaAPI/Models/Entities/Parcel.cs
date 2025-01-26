using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class Parcel
{
    [Key] public Guid Id { get; init; }
    [MaxLength(50)] public required string ParcelName { get; init; }
    public int CadastreParcelNumber { get; init; }
    public double Area { get; init; }
    [MaxLength(50)] public required string Address { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public Guid UserId { get; init; }
    public required User User { get; init; }
}