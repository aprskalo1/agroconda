using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.Entities;

public class Asset
{
    [Key] public Guid Id { get; init; }
    
    public required string Base64Image { get; init; }
    public required string FileName { get; init; }
    public required string MimeType { get; init; }
    
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}