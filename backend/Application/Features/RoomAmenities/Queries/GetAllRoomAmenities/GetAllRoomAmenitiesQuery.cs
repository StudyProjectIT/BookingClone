using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RoomAmenities.Queries.GetAllRoomAmenities;

public record GetAllRoomAmenitiesQuery(int Page, int PageSize) : IRequest<Result<PagedResult<RoomAmenityDto>>>;
