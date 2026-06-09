using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RentalPeriods.Commands;

public class UpdateRentalPeriodHandler(IRepository<RentalPeriod> repository)
    : IRequestHandler<UpdateRentalPeriodCommand, Result<RentalPeriodDto>>
{
    public async Task<Result<RentalPeriodDto>> Handle(UpdateRentalPeriodCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Rental period with id {request.Id} not found.");
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Rental period name is required.");
        entity.Name = request.Name;
        await repository.UpdateAsync(entity, ct);
        return RentalPeriodMappings.MapToDto(entity);
    }
}
