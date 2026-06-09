using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelAmenities.Queries.GetHotelAmenityById;

public class GetHotelAmenityByIdHandler(IRepository<HotelAmenity> repository)
    : IRequestHandler<GetHotelAmenityByIdQuery, Result<HotelAmenityDto>>
{
    public async Task<Result<HotelAmenityDto>> Handle(GetHotelAmenityByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Hotel amenity with id {request.Id} not found.");

        return HotelAmenityMappings.MapToDto(entity);
    }
}
