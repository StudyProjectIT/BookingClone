using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomAmenities.Commands.UpdateRoomAmenity;

public class UpdateRoomAmenityHandler(IRepository<RoomAmenity> repository)
    : IRequestHandler<UpdateRoomAmenityCommand, Result<RoomAmenityDto>>
{
    public async Task<Result<RoomAmenityDto>> Handle(UpdateRoomAmenityCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Room amenity with id {request.Id} not found.");

        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Room amenity name is required.");

        entity.Name = request.Name;
        await repository.UpdateAsync(entity, ct);
        return RoomAmenityMappings.MapToDto(entity);
    }
}
