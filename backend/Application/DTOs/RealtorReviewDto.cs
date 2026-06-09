namespace Application.DTOs;

public class RealtorReviewDto
{
    public long Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public double? Score { get; set; }
    public long AuthorId { get; set; }
    public long RealtorId { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
}
