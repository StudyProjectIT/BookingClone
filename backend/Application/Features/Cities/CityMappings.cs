using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Cities;

internal static class CityMappings
{
    internal static CityDto MapToDto(City c) => new()
    {
        Id = c.Id,
        Name = c.Name,
        Image = c.Image,
        Longitude = c.Longitude,
        Latitude = c.Latitude,
        CountryId = c.CountryId,
        CountryName = c.Country?.Name ?? string.Empty
    };
}
