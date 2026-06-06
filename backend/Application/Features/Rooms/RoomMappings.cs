using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Rooms;

internal static class RoomMappings
{
    internal static RoomDto MapToDto(Room r) => new()
    {
        Id = r.Id,
        Name = r.Name,
        Area = r.Area,
        NumberOfRooms = r.NumberOfRooms,
        Quantity = r.Quantity,
        HotelId = r.HotelId,
        RoomTypeId = r.RoomTypeId
    };
}
