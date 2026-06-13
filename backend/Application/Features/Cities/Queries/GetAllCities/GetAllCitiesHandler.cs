using Application.DTOs;
using Domain.Common;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Cities.Queries.GetAllCities;

public class GetAllCitiesHandler(ICityRepository repository)
    : IRequestHandler<GetAllCitiesQuery, Result<PagedResult<CityDto>>>
{
    public async Task<Result<PagedResult<CityDto>>> Handle(GetAllCitiesQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await repository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<CityDto>
        {
            Items = items.Select(CityMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
