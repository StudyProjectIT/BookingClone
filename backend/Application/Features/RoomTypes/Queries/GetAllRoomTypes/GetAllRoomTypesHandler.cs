using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomTypes.Queries.GetAllRoomTypes;

public class GetAllRoomTypesHandler(IRepository<RoomType> repository)
    : IRequestHandler<GetAllRoomTypesQuery, Result<PagedResult<RoomTypeDto>>>
{
    public async Task<Result<PagedResult<RoomTypeDto>>> Handle(GetAllRoomTypesQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await repository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<RoomTypeDto>
        {
            Items = items.Select(RoomTypeMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
