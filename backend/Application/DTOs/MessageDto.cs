namespace Application.DTOs;

public class MessageDto
{
    public long Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public long ChatId { get; set; }
    public long AuthorId { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
}
