using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomVariants.Commands.DeleteRoomVariant;

public class DeleteRoomVariantHandler(IRoomVariantRepository repository)
    : IRequestHandler<DeleteRoomVariantCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteRoomVariantCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Room variant with id {request.Id} not found.");
        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
