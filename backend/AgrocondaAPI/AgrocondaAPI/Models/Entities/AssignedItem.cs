using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class AssignedItem
{
    [Key] public Guid Id { get; init; }

    public Guid AssignerId { get; init; }
    public required User Assigner { get; init; }

    public Guid AssignedId { get; init; }
    public required User Assigned { get; init; }

    [MaxLength(250)] public string? AssignNote { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}