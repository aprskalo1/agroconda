using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class ParcelGroup
{
    [Key] public Guid Id { get; init; }

    public Guid ParcelId { get; init; }
    public required Parcel Parcel { get; init; }

    public Guid GroupId { get; init; }
    public required Group Group { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}