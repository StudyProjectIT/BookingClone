using Domain.Common;
using MediatR;

namespace Application.Features.RoomVariants.Commands.DeleteRoomVariant;

public record DeleteRoomVariantCommand(long Id) : IRequest<Result<bool>>;
