using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Hotels;

internal static class HotelMappings
{
    internal static HotelDto MapToDto(Hotel h) => new()
    {
        Id = (int)h.Id,
        Name = h.Name,
        Description = h.Description,
        Location = h.Address?.City?.Name ?? string.Empty
    };
}
