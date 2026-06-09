using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Chats.Queries.GetChatById;

public class GetChatByIdHandler(IRepository<Chat> repository)
    : IRequestHandler<GetChatByIdQuery, Result<ChatDto>>
{
    public async Task<Result<ChatDto>> Handle(GetChatByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Chat with id {request.Id} not found.");
        return ChatMappings.MapToDto(entity);
    }
}
