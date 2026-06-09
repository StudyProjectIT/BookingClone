using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Countries.Commands.UpdateCountry;

public class UpdateCountryHandler(IRepository<Country> repository)
    : IRequestHandler<UpdateCountryCommand, Result<CountryDto>>
{
    public async Task<Result<CountryDto>> Handle(UpdateCountryCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Country with id {request.Id} not found.");

        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Country name is required.");

        entity.Name = request.Name;
        entity.Image = request.Image;
        await repository.UpdateAsync(entity, ct);
        return CountryMappings.MapToDto(entity);
    }
}
