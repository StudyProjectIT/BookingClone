namespace Application.DTOs;

public class RoomDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Area { get; set; }
    public int NumberOfRooms { get; set; }
    public int Quantity { get; set; }
    public long HotelId { get; set; }
    public long RoomTypeId { get; set; }
}
