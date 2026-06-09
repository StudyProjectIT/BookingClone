using Domain.Common;
using MediatR;

namespace Application.Features.RoomTypes.Commands.DeleteRoomType;

public record DeleteRoomTypeCommand(long Id) : IRequest<Result<bool>>;
