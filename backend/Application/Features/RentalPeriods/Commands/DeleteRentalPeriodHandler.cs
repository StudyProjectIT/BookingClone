using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RentalPeriods.Commands;

public class DeleteRentalPeriodHandler(IRepository<RentalPeriod> repository)
    : IRequestHandler<DeleteRentalPeriodCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteRentalPeriodCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Rental period with id {request.Id} not found.");
        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
