using Application.DTOs;
using Domain.Entities;

namespace Application.Features.RoomAmenities;

internal static class RoomAmenityMappings
{
    internal static RoomAmenityDto MapToDto(RoomAmenity e) => new() { Id = e.Id, Name = e.Name };
}
