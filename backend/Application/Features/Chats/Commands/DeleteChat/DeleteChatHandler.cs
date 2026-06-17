using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Chats.Commands.DeleteChat;

public class DeleteChatHandler(IRepository<Chat> repository, ICurrentUserService currentUser)
    : IRequestHandler<DeleteChatCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteChatCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Chat with id {request.Id} not found.");

        var userId = currentUser.GetUserId();
        if (entity.CustomerId != userId && entity.RealtorId != userId)
            return Error.Forbidden("You do not have access to this resource.");

        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
