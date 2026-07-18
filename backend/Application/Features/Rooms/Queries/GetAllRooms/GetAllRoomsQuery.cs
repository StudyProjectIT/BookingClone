using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Rooms.Queries.GetAllRooms;

public record GetAllRoomsQuery(int Page, int PageSize) : IRequest<Result<PagedResult<RoomDto>>>;
