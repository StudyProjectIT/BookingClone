using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RoomTypes.Commands.UpdateRoomType;

public record UpdateRoomTypeCommand(long Id, string Name) : IRequest<Result<RoomTypeDto>>;
