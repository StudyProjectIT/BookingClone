using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Genders.Commands;

public class UpdateGenderHandler(IRepository<Gender> repository)
    : IRequestHandler<UpdateGenderCommand, Result<GenderDto>>
{
    public async Task<Result<GenderDto>> Handle(UpdateGenderCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Gender with id {request.Id} not found.");
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Gender name is required.");
        entity.Name = request.Name;
        await repository.UpdateAsync(entity, ct);
        return GenderMappings.MapToDto(entity);
    }
}
