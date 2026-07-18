using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Rooms.Queries.GetAllRooms;

public class GetAllRoomsHandler(IRepository<Room> repository)
    : IRequestHandler<GetAllRoomsQuery, Result<PagedResult<RoomDto>>>
{
    public async Task<Result<PagedResult<RoomDto>>> Handle(GetAllRoomsQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await repository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<RoomDto>
        {
            Items = items.Select(RoomMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
