using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Cities.Commands.CreateCity;

public class CreateCityHandler(IRepository<City> repository)
    : IRequestHandler<CreateCityCommand, Result<CityDto>>
{
    public async Task<Result<CityDto>> Handle(CreateCityCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("City name is required.");

        var entity = new City
        {
            Name = request.Name,
            Image = request.Image,
            Longitude = request.Longitude,
            Latitude = request.Latitude,
            CountryId = request.CountryId
        };
        var created = await repository.AddAsync(entity, ct);
        return CityMappings.MapToDto(created);
    }
}
