namespace AgrocondaAPI.Models.Common;

public class ErrorResponse
{
    public required string Message { get; set; }
    public required string StatusCode { get; set; }
    public DateTime TimeStamp { get; set; } = DateTime.Now;
}