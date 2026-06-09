using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Cities.Commands.UpdateCity;

public class UpdateCityHandler(IRepository<City> repository)
    : IRequestHandler<UpdateCityCommand, Result<CityDto>>
{
    public async Task<Result<CityDto>> Handle(UpdateCityCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"City with id {request.Id} not found.");

        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("City name is required.");

        entity.Name = request.Name;
        entity.Image = request.Image;
        entity.Longitude = request.Longitude;
        entity.Latitude = request.Latitude;
        entity.CountryId = request.CountryId;
        await repository.UpdateAsync(entity, ct);
        return CityMappings.MapToDto(entity);
    }
}
