using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Breakfasts.Commands;

public class UpdateBreakfastHandler(IRepository<Breakfast> repository)
    : IRequestHandler<UpdateBreakfastCommand, Result<BreakfastDto>>
{
    public async Task<Result<BreakfastDto>> Handle(UpdateBreakfastCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Breakfast with id {request.Id} not found.");
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Breakfast name is required.");
        entity.Name = request.Name;
        await repository.UpdateAsync(entity, ct);
        return BreakfastMappings.MapToDto(entity);
    }
}
