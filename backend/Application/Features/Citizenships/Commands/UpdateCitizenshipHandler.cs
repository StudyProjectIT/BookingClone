using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Citizenships.Commands;

public class UpdateCitizenshipHandler(IRepository<Citizenship> repository)
    : IRequestHandler<UpdateCitizenshipCommand, Result<CitizenshipDto>>
{
    public async Task<Result<CitizenshipDto>> Handle(UpdateCitizenshipCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Citizenship with id {request.Id} not found.");
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Citizenship name is required.");
        entity.Name = request.Name;
        await repository.UpdateAsync(entity, ct);
        return CitizenshipMappings.MapToDto(entity);
    }
}
