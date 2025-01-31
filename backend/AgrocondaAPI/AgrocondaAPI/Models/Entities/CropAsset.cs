using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class CropAsset
{
    [Key] public Guid Id { get; init; }

    public Guid CropId { get; init; }
    public required Crop Crop { get; init; }

    public Guid AssetId { get; init; }
    public required Asset Asset { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}