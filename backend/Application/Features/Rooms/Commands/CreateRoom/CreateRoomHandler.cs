using Application.DTOs;
using Application.Features.Rooms;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Rooms.Commands.CreateRoom;

public class CreateRoomHandler(IRoomRepository roomRepository)
    : IRequestHandler<CreateRoomCommand, Result<RoomDto>>
{
    public async Task<Result<RoomDto>> Handle(CreateRoomCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Room name is required.");

        var room = new Room
        {
            Name = request.Name,
            Area = request.Area,
            NumberOfRooms = request.NumberOfRooms,
            Quantity = request.Quantity,
            HotelId = request.HotelId,
            RoomTypeId = request.RoomTypeId
        };

        var created = await roomRepository.AddAsync(room, ct);
        return RoomMappings.MapToDto(created);
    }
}
