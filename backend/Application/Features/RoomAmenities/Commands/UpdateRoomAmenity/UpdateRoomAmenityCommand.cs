using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RoomAmenities.Commands.UpdateRoomAmenity;

public record UpdateRoomAmenityCommand(long Id, string Name) : IRequest<Result<RoomAmenityDto>>;
