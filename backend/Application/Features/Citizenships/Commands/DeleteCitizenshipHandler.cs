using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Citizenships.Commands;

public class DeleteCitizenshipHandler(IRepository<Citizenship> repository)
    : IRequestHandler<DeleteCitizenshipCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteCitizenshipCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Citizenship with id {request.Id} not found.");
        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
