namespace Application.DTOs.Auth;

public class LoginDto
{
    public string EmailOrUserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
