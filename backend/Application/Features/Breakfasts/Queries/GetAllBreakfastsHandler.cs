using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Breakfasts.Queries;

public class GetAllBreakfastsHandler(IRepository<Breakfast> repository)
    : IRequestHandler<GetAllBreakfastsQuery, Result<PagedResult<BreakfastDto>>>
{
    public async Task<Result<PagedResult<BreakfastDto>>> Handle(GetAllBreakfastsQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await repository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<BreakfastDto>
        {
            Items = items.Select(BreakfastMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
