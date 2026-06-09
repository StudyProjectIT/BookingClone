using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Genders.Queries;

public class GetGenderByIdHandler(IRepository<Gender> repository)
    : IRequestHandler<GetGenderByIdQuery, Result<GenderDto>>
{
    public async Task<Result<GenderDto>> Handle(GetGenderByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Gender with id {request.Id} not found.");
        return GenderMappings.MapToDto(entity);
    }
}
