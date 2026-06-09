namespace Application.DTOs;

public class CityDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public long CountryId { get; set; }
    public string CountryName { get; set; } = string.Empty;
}
