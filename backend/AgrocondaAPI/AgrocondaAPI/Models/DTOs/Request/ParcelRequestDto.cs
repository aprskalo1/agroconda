using System.ComponentModel.DataAnnotations;

namespace AgrocondaAPI.Models.DTOs.Request;

public class ParcelRequestDto
{
    [Required] [MaxLength(50)] public required string ParcelName { get; init; }
    public int CadastreParcelNumber { get; init; }
    public double Area { get; init; }
    [MaxLength(350)] public required string Address { get; init; }
    [Required] public double Latitude { get; init; }
    [Required] public double Longitude { get; init; }
}