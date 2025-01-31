using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class AssignedItemGroup
{
    [Key] public Guid Id { get; init; }

    public Guid AssignedItemId { get; init; }
    public required AssignedItem AssignedItem { get; init; }

    public Guid GroupId { get; init; }
    public required Group Group { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}