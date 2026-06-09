using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RentalPeriods.Queries;

public class GetAllRentalPeriodsHandler(IRepository<RentalPeriod> repository)
    : IRequestHandler<GetAllRentalPeriodsQuery, Result<PagedResult<RentalPeriodDto>>>
{
    public async Task<Result<PagedResult<RentalPeriodDto>>> Handle(GetAllRentalPeriodsQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await repository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<RentalPeriodDto>
        {
            Items = items.Select(RentalPeriodMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
