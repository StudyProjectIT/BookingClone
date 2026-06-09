using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Citizenships.Commands;

public class CreateCitizenshipHandler(IRepository<Citizenship> repository)
    : IRequestHandler<CreateCitizenshipCommand, Result<CitizenshipDto>>
{
    public async Task<Result<CitizenshipDto>> Handle(CreateCitizenshipCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Citizenship name is required.");
        var entity = new Citizenship { Name = request.Name };
        var created = await repository.AddAsync(entity, ct);
        return CitizenshipMappings.MapToDto(created);
    }
}
