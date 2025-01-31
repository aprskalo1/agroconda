using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class CropGroup
{
    [Key] public Guid Id { get; init; }

    public Guid CropId { get; init; }
    public required Crop Crop { get; init; }

    public Guid GroupId { get; init; }
    public required Group Group { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}