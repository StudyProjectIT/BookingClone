using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Rooms.Commands.DeleteRoom;

public class DeleteRoomHandler(IRoomRepository roomRepository)
    : IRequestHandler<DeleteRoomCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteRoomCommand request, CancellationToken ct)
    {
        var room = await roomRepository.GetByIdAsync(request.Id, ct);
        if (room is null)
            return Error.NotFound($"Room with id {request.Id} not found.");

        await roomRepository.DeleteAsync(request.Id, ct);
        return true;
    }
}
