using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class User
{
    [Key] public Guid Id { get; init; }
    [MaxLength(50)] public string? FirebaseUid { get; init; }
    [MaxLength(50)] public required string Username { get; init; }
    [MaxLength(50)] public string? FirstName { get; init; }
    [MaxLength(50)] public string? LastName { get; init; }
    [MaxLength(50)] public required string Email { get; init; }
    [MaxLength(50)] public string? PhoneNumber { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}