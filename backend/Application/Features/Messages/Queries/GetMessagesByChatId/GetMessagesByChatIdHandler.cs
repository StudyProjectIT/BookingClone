using Application.DTOs;
using Domain.Common;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Messages.Queries.GetMessagesByChatId;

public class GetMessagesByChatIdHandler(IMessageRepository repository)
    : IRequestHandler<GetMessagesByChatIdQuery, Result<IReadOnlyList<MessageDto>>>
{
    public async Task<Result<IReadOnlyList<MessageDto>>> Handle(GetMessagesByChatIdQuery request, CancellationToken ct)
    {
        var messages = await repository.GetByChatIdAsync(request.ChatId, ct);
        return messages.Select(MessageMappings.MapToDto).ToList().AsReadOnly();
    }
}
