using Domain.Common;
using MediatR;

namespace Application.Features.Rooms.Commands.DeleteRoom;

public record DeleteRoomCommand(long Id) : IRequest<Result<bool>>;
