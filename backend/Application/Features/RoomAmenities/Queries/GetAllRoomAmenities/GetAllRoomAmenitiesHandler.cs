using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomAmenities.Queries.GetAllRoomAmenities;

public class GetAllRoomAmenitiesHandler(IRepository<RoomAmenity> repository)
    : IRequestHandler<GetAllRoomAmenitiesQuery, Result<PagedResult<RoomAmenityDto>>>
{
    public async Task<Result<PagedResult<RoomAmenityDto>>> Handle(GetAllRoomAmenitiesQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await repository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<RoomAmenityDto>
        {
            Items = items.Select(RoomAmenityMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
