using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class Group
{
    [Key] public Guid Id { get; init; }

    [MaxLength(50)] public required string GroupName { get; init; }
    [MaxLength(250)] public string? Description { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}