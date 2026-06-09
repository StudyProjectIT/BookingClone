using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RoomTypes.Queries.GetAllRoomTypes;

public record GetAllRoomTypesQuery(int Page, int PageSize) : IRequest<Result<PagedResult<RoomTypeDto>>>;
