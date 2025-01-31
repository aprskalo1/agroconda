using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class Crop
{
    [Key] public Guid Id { get; set; }

    public Guid ParcelId { get; set; }
    public required Parcel Parcel { get; set; }

    [MaxLength(50)] public required string CropType { get; set; }
    public int Quantity { get; set; }
    [MaxLength(500)] public string? Description { get; set; }
    public DateTime SowingDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}