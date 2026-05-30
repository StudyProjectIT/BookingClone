using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Auth;

public class ProfileUpdateDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    [Required, MinLength(3), MaxLength(64)]
    public string UserName { get; set; } = null!;

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;
}
