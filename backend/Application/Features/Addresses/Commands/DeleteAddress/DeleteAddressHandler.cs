using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Addresses.Commands.DeleteAddress;

public class DeleteAddressHandler(IAddressRepository repository)
    : IRequestHandler<DeleteAddressCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteAddressCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Address with id {request.Id} not found.");

        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
