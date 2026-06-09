using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomAmenities.Commands.DeleteRoomAmenity;

public class DeleteRoomAmenityHandler(IRepository<RoomAmenity> repository)
    : IRequestHandler<DeleteRoomAmenityCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteRoomAmenityCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Room amenity with id {request.Id} not found.");

        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
