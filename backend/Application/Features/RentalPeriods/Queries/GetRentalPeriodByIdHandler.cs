using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RentalPeriods.Queries;

public class GetRentalPeriodByIdHandler(IRepository<RentalPeriod> repository)
    : IRequestHandler<GetRentalPeriodByIdQuery, Result<RentalPeriodDto>>
{
    public async Task<Result<RentalPeriodDto>> Handle(GetRentalPeriodByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Rental period with id {request.Id} not found.");
        return RentalPeriodMappings.MapToDto(entity);
    }
}
