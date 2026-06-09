using Application.DTOs;
using Domain.Entities;

namespace Application.Features.HotelAmenities;

internal static class HotelAmenityMappings
{
    internal static HotelAmenityDto MapToDto(HotelAmenity e) => new() { Id = e.Id, Name = e.Name, Image = e.Image };
}
