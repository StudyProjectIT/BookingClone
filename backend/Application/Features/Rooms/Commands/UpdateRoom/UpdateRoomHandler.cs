using Application.DTOs;
using Application.Features.Rooms;
using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Rooms.Commands.UpdateRoom;

public class UpdateRoomHandler(IRoomRepository roomRepository)
    : IRequestHandler<UpdateRoomCommand, Result<RoomDto>>
{
    public async Task<Result<RoomDto>> Handle(UpdateRoomCommand request, CancellationToken ct)
    {
        var room = await roomRepository.GetByIdAsync(request.Id, ct);
        if (room is null)
            return Error.NotFound($"Room with id {request.Id} not found.");

        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Room name is required.");

        room.Name = request.Name;
        room.Area = request.Area;
        room.NumberOfRooms = request.NumberOfRooms;
        room.Quantity = request.Quantity;
        room.RoomTypeId = request.RoomTypeId;

        await roomRepository.UpdateAsync(room, ct);
        return RoomMappings.MapToDto(room);
    }
}
