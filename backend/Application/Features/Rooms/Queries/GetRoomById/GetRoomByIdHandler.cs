using Application.DTOs;
using Application.Features.Rooms;
using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Rooms.Queries.GetRoomById;

public class GetRoomByIdHandler(IRoomRepository roomRepository)
    : IRequestHandler<GetRoomByIdQuery, Result<RoomDto>>
{
    public async Task<Result<RoomDto>> Handle(GetRoomByIdQuery request, CancellationToken ct)
    {
        var room = await roomRepository.GetByIdAsync(request.Id, ct);
        if (room is null)
            return Error.NotFound($"Room with id {request.Id} not found.");
        return RoomMappings.MapToDto(room);
    }
}
