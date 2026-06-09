using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Countries;

internal static class CountryMappings
{
    internal static CountryDto MapToDto(Country c) => new()
    {
        Id = c.Id,
        Name = c.Name,
        Image = c.Image
    };
}
