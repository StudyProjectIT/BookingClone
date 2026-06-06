using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Rooms.Commands.UpdateRoom;

public record UpdateRoomCommand(
    long Id,
    string Name,
    double Area,
    int NumberOfRooms,
    int Quantity,
    long RoomTypeId
) : IRequest<Result<RoomDto>>;
