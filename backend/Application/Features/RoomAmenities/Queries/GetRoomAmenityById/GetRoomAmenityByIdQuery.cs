using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RoomAmenities.Queries.GetRoomAmenityById;

public record GetRoomAmenityByIdQuery(long Id) : IRequest<Result<RoomAmenityDto>>;
