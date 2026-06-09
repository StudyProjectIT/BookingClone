using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Cities.Commands.DeleteCity;

public class DeleteCityHandler(IRepository<City> repository)
    : IRequestHandler<DeleteCityCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteCityCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"City with id {request.Id} not found.");

        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
