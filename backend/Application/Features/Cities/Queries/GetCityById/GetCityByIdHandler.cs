using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Cities.Queries.GetCityById;

public class GetCityByIdHandler(ICityRepository repository)
    : IRequestHandler<GetCityByIdQuery, Result<CityDto>>
{
    public async Task<Result<CityDto>> Handle(GetCityByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"City with id {request.Id} not found.");

        return CityMappings.MapToDto(entity);
    }
}
