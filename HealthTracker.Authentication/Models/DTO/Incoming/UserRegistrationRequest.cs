using System.ComponentModel.DataAnnotations;

namespace HealthTracker.Authentication.Models.DTO.Incoming;

public class UserRegistrationRequest
{
    [Required]
    public string FirstName { get; set; } = String.Empty;

    [Required]
    public string LastName { get; set; } = String.Empty;

    [Required]
    public string Email { get; set; } = String.Empty;

    [Required]
    public string Password { get; set; } = String.Empty;
}