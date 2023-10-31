namespace HealthTracker.Authentication.Models.DTO.Outgoing;

public class AuthResult
{
    public string Token { get; set; } = String.Empty;
    public bool Success { get; set; }
    public List<string>? Errors { get; set; }
}