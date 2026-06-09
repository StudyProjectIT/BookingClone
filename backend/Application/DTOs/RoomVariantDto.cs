namespace Application.DTOs;

public class RoomVariantDto
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public long RoomId { get; set; }
    public int AdultCount { get; set; }
    public int ChildCount { get; set; }
    public int SingleBedCount { get; set; }
    public int DoubleBedCount { get; set; }
    public int ExtraBedCount { get; set; }
    public int SofaCount { get; set; }
    public int KingsizeBedCount { get; set; }
}
