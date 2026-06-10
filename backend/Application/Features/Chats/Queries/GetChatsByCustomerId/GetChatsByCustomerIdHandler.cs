using Application.DTOs;
using Domain.Common;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Chats.Queries.GetChatsByCustomerId;

public class GetChatsByCustomerIdHandler(IChatRepository repository)
    : IRequestHandler<GetChatsByCustomerIdQuery, Result<IReadOnlyList<ChatDto>>>
{
    public async Task<Result<IReadOnlyList<ChatDto>>> Handle(GetChatsByCustomerIdQuery request, CancellationToken ct)
    {
        var chats = await repository.GetByCustomerIdAsync(request.CustomerId, ct);
        return chats.Select(ChatMappings.MapToDto).ToList().AsReadOnly();
    }
}
