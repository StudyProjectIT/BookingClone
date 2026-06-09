namespace Application.DTOs;

public class HotelPhotoDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Priority { get; set; }
    public long HotelId { get; set; }
}
