using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Genders.Commands;

public class DeleteGenderHandler(IRepository<Gender> repository)
    : IRequestHandler<DeleteGenderCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteGenderCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Gender with id {request.Id} not found.");
        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
