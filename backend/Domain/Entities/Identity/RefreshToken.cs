namespace Domain.Entities.Identity;

public class RefreshToken
{
    public long Id { get; set; }
    public string Token { get; set; } = null!;
    public DateTimeOffset ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public long UserId { get; set; }
    public AppUser User { get; set; } = null!;
}
