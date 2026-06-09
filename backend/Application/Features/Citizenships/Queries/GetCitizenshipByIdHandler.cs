using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Citizenships.Queries;

public class GetCitizenshipByIdHandler(IRepository<Citizenship> repository)
    : IRequestHandler<GetCitizenshipByIdQuery, Result<CitizenshipDto>>
{
    public async Task<Result<CitizenshipDto>> Handle(GetCitizenshipByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Citizenship with id {request.Id} not found.");
        return CitizenshipMappings.MapToDto(entity);
    }
}
