namespace Application.DTOs;

public class AddressDto
{
    public long Id { get; set; }
    public string Street { get; set; } = string.Empty;
    public string HouseNumber { get; set; } = string.Empty;
    public int? Floor { get; set; }
    public string? ApartmentNumber { get; set; }
    public long CityId { get; set; }
    public string CityName { get; set; } = string.Empty;
}
