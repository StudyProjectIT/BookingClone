using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Citizenships.Queries;

public class GetAllCitizenshipsHandler(IRepository<Citizenship> repository)
    : IRequestHandler<GetAllCitizenshipsQuery, Result<PagedResult<CitizenshipDto>>>
{
    public async Task<Result<PagedResult<CitizenshipDto>>> Handle(GetAllCitizenshipsQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await repository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<CitizenshipDto>
        {
            Items = items.Select(CitizenshipMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
