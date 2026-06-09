using Domain.Common;
using MediatR;

namespace Application.Features.RoomAmenities.Commands.DeleteRoomAmenity;

public record DeleteRoomAmenityCommand(long Id) : IRequest<Result<bool>>;
