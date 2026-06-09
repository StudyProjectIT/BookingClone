using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RoomTypes.Commands.DeleteRoomType;

public class DeleteRoomTypeHandler(IRepository<RoomType> repository)
    : IRequestHandler<DeleteRoomTypeCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteRoomTypeCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Room type with id {request.Id} not found.");

        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
