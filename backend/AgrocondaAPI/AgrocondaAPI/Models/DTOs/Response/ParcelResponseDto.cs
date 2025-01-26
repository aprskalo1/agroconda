namespace AgrocondaAPI.Models.DTOs.Response;

public class ParcelResponseDto
{
    public Guid Id { get; init; }
    public string ParcelName { get; init; }
    public int CadastreParcelNumber { get; init; }
    public double Area { get; init; }
    public string Address { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public DateTime CreatedAt { get; init; }
}