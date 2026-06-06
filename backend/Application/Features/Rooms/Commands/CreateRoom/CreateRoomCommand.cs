using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(
    string Name,
    double Area,
    int NumberOfRooms,
    int Quantity,
    long HotelId,
    long RoomTypeId
) : IRequest<Result<RoomDto>>;
