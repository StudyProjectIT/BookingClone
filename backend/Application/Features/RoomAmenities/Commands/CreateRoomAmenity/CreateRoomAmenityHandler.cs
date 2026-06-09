using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomAmenities.Commands.CreateRoomAmenity;

public class CreateRoomAmenityHandler(IRepository<RoomAmenity> repository)
    : IRequestHandler<CreateRoomAmenityCommand, Result<RoomAmenityDto>>
{
    public async Task<Result<RoomAmenityDto>> Handle(CreateRoomAmenityCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Room amenity name is required.");

        var entity = new RoomAmenity { Name = request.Name };
        var created = await repository.AddAsync(entity, ct);
        return RoomAmenityMappings.MapToDto(created);
    }
}
