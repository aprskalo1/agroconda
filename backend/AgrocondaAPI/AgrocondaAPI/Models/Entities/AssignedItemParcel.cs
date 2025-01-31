using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class AssignedItemParcel
{
    [Key] public Guid Id { get; init; }

    public Guid AssignedItemId { get; init; }
    public required AssignedItem AssignedItem { get; init; }

    public Guid ParcelId { get; init; }
    public required Parcel Parcel { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}