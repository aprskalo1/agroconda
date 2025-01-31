using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class AgroTask
{
    [Key] public Guid Id { get; init; }

    public Guid ParcelId { get; init; }
    public required Parcel Parcel { get; init; }

    [MaxLength(50)] public required string TaskName { get; init; }
    [MaxLength(1000)] public required string Description { get; init; }
    public DateTime DueDate { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}