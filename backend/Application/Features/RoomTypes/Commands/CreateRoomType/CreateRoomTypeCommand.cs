using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RoomTypes.Commands.CreateRoomType;

public record CreateRoomTypeCommand(string Name) : IRequest<Result<RoomTypeDto>>;
