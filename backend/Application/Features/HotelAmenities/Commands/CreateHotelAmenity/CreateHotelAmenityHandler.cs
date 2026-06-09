using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelAmenities.Commands.CreateHotelAmenity;

public class CreateHotelAmenityHandler(IRepository<HotelAmenity> repository)
    : IRequestHandler<CreateHotelAmenityCommand, Result<HotelAmenityDto>>
{
    public async Task<Result<HotelAmenityDto>> Handle(CreateHotelAmenityCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Hotel amenity name is required.");

        var entity = new HotelAmenity { Name = request.Name, Image = request.Image };
        var created = await repository.AddAsync(entity, ct);
        return HotelAmenityMappings.MapToDto(created);
    }
}
