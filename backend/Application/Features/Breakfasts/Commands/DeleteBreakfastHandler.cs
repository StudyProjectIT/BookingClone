using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Breakfasts.Commands;

public class DeleteBreakfastHandler(IRepository<Breakfast> repository)
    : IRequestHandler<DeleteBreakfastCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteBreakfastCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Breakfast with id {request.Id} not found.");
        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
