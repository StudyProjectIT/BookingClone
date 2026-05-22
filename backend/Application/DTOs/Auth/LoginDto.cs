using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Auth;

public class LoginDto
{
    [Required]
    public string EmailOrUserName { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
