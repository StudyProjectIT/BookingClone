using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelAmenities.Queries.GetAllHotelAmenities;

public class GetAllHotelAmenitiesHandler(IRepository<HotelAmenity> repository)
    : IRequestHandler<GetAllHotelAmenitiesQuery, Result<PagedResult<HotelAmenityDto>>>
{
    public async Task<Result<PagedResult<HotelAmenityDto>>> Handle(GetAllHotelAmenitiesQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await repository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<HotelAmenityDto>
        {
            Items = items.Select(HotelAmenityMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
