using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class CropAgroNote
{
    [Key] public Guid Id { get; init; }

    public Guid CropId { get; init; }
    public required Crop Crop { get; init; }

    public Guid AgroNoteId { get; init; }
    public required AgroNote AgroNote { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}