using System.ComponentModel.DataAnnotations;
using AgrocondaAPI.Models.Enum;

namespace AgrocondaAPI.Models.Entities;

public class AgroNote
{
    [Key] public Guid Id { get; init; }

    [MaxLength(50)] public required string Title { get; init; }
    [MaxLength(1000)] public required string Content { get; init; }

    [EnumDataType(typeof(NoteType))] public NoteType NoteType { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}