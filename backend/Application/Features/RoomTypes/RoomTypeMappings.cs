using Application.DTOs;
using Domain.Entities;

namespace Application.Features.RoomTypes;

internal static class RoomTypeMappings
{
    internal static RoomTypeDto MapToDto(RoomType e) => new() { Id = e.Id, Name = e.Name };
}
