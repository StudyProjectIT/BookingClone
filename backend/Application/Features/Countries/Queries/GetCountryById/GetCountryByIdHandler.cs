using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Countries.Queries.GetCountryById;

public class GetCountryByIdHandler(IRepository<Country> repository)
    : IRequestHandler<GetCountryByIdQuery, Result<CountryDto>>
{
    public async Task<Result<CountryDto>> Handle(GetCountryByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Country with id {request.Id} not found.");

        return CountryMappings.MapToDto(entity);
    }
}
