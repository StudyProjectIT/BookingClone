using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Countries.Commands.CreateCountry;

public class CreateCountryHandler(IRepository<Country> repository)
    : IRequestHandler<CreateCountryCommand, Result<CountryDto>>
{
    public async Task<Result<CountryDto>> Handle(CreateCountryCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Country name is required.");

        var entity = new Country { Name = request.Name, Image = request.Image };
        var created = await repository.AddAsync(entity, ct);
        return CountryMappings.MapToDto(created);
    }
}
