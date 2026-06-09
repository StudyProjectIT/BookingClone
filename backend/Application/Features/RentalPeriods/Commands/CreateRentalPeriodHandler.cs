using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RentalPeriods.Commands;

public class CreateRentalPeriodHandler(IRepository<RentalPeriod> repository)
    : IRequestHandler<CreateRentalPeriodCommand, Result<RentalPeriodDto>>
{
    public async Task<Result<RentalPeriodDto>> Handle(CreateRentalPeriodCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Rental period name is required.");
        var entity = new RentalPeriod { Name = request.Name };
        var created = await repository.AddAsync(entity, ct);
        return RentalPeriodMappings.MapToDto(created);
    }
}
