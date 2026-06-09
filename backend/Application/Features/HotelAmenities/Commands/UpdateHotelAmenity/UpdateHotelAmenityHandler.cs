using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelAmenities.Commands.UpdateHotelAmenity;

public class UpdateHotelAmenityHandler(IRepository<HotelAmenity> repository)
    : IRequestHandler<UpdateHotelAmenityCommand, Result<HotelAmenityDto>>
{
    public async Task<Result<HotelAmenityDto>> Handle(UpdateHotelAmenityCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Hotel amenity with id {request.Id} not found.");

        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Hotel amenity name is required.");

        entity.Name = request.Name;
        entity.Image = request.Image;
        await repository.UpdateAsync(entity, ct);
        return HotelAmenityMappings.MapToDto(entity);
    }
}
