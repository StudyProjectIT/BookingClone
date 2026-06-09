using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomAmenities.Queries.GetRoomAmenityById;

public class GetRoomAmenityByIdHandler(IRepository<RoomAmenity> repository)
    : IRequestHandler<GetRoomAmenityByIdQuery, Result<RoomAmenityDto>>
{
    public async Task<Result<RoomAmenityDto>> Handle(GetRoomAmenityByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Room amenity with id {request.Id} not found.");

        return RoomAmenityMappings.MapToDto(entity);
    }
}
