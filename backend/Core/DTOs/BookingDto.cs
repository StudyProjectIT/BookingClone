namespace Core.DTOs
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Guests { get; set; }
        public decimal TotalPrice { get; set; }
    }
}