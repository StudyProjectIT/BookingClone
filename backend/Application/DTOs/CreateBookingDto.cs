using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class CreateBookingDto
{
    [Required]
    public int HotelId { get; set; }

    [Required]
    public DateTime CheckIn { get; set; }

    [Required]
    public DateTime CheckOut { get; set; }

    [Range(1, 100)]
    public int Guests { get; set; } = 1;

    [Range(0, double.MaxValue)]
    public decimal TotalPrice { get; set; }

    public string? PersonalWishes { get; set; }
}
