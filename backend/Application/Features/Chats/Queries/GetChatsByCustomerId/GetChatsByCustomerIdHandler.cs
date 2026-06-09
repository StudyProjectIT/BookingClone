using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Chats.Queries.GetChatsByCustomerId;

public class GetChatsByCustomerIdHandler(IRepository<Chat> repository)
    : IRequestHandler<GetChatsByCustomerIdQuery, Result<IReadOnlyList<ChatDto>>>
{
    public async Task<Result<IReadOnlyList<ChatDto>>> Handle(GetChatsByCustomerIdQuery request, CancellationToken ct)
    {
        var all = await repository.GetAllAsync(ct);
        return all.Where(c => c.CustomerId == request.CustomerId)
                  .Select(ChatMappings.MapToDto)
                  .ToList()
                  .AsReadOnly();
    }
}
