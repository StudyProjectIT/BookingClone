using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RoomAmenities.Commands.CreateRoomAmenity;

public record CreateRoomAmenityCommand(string Name) : IRequest<Result<RoomAmenityDto>>;
