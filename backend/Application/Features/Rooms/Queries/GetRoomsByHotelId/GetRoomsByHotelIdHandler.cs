using Application.DTOs;
using Application.Features.Rooms;
using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Rooms.Queries.GetRoomsByHotelId;

public class GetRoomsByHotelIdHandler(IRoomRepository roomRepository)
    : IRequestHandler<GetRoomsByHotelIdQuery, Result<List<RoomDto>>>
{
    public async Task<Result<List<RoomDto>>> Handle(GetRoomsByHotelIdQuery request, CancellationToken ct)
    {
        var rooms = await roomRepository.GetByHotelIdAsync(request.HotelId, ct);
        return rooms.Select(RoomMappings.MapToDto).ToList();
    }
}
