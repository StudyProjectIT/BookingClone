using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Countries.Queries.GetAllCountries;

public class GetAllCountriesHandler(IRepository<Country> repository)
    : IRequestHandler<GetAllCountriesQuery, Result<PagedResult<CountryDto>>>
{
    public async Task<Result<PagedResult<CountryDto>>> Handle(GetAllCountriesQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await repository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<CountryDto>
        {
            Items = items.Select(CountryMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
