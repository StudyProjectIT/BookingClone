using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Messages.Commands.DeleteMessage;

public class DeleteMessageHandler(IRepository<Message> repository)
    : IRequestHandler<DeleteMessageCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteMessageCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Message with id {request.Id} not found.");
        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
