using Application.DTOs;
using Domain.Entities;

namespace Application.Features.HotelPhotos;

internal static class HotelPhotoMappings
{
    internal static HotelPhotoDto MapToDto(HotelPhoto e) => new()
    {
        Id = e.Id,
        Name = e.Name,
        Priority = e.Priority,
        HotelId = e.HotelId
    };
}
