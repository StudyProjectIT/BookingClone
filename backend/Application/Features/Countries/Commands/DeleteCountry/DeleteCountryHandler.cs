using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Countries.Commands.DeleteCountry;

public class DeleteCountryHandler(IRepository<Country> repository)
    : IRequestHandler<DeleteCountryCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteCountryCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Country with id {request.Id} not found.");

        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
