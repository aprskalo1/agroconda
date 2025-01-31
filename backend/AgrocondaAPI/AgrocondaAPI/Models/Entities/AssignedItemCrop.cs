using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class AssignedItemCrop
{
    [Key] public Guid Id { get; init; }

    public Guid AssignedItemId { get; init; }
    public required AssignedItem AssignedItem { get; init; }

    public Guid CropId { get; init; }
    public required Crop Crop { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}