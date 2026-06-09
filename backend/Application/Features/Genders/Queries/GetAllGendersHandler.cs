using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Genders.Queries;

public class GetAllGendersHandler(IRepository<Gender> repository)
    : IRequestHandler<GetAllGendersQuery, Result<PagedResult<GenderDto>>>
{
    public async Task<Result<PagedResult<GenderDto>>> Handle(GetAllGendersQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await repository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<GenderDto>
        {
            Items = items.Select(GenderMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
