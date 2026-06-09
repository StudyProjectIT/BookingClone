using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Chats.Commands.CreateChat;

public class CreateChatHandler(IRepository<Chat> repository)
    : IRequestHandler<CreateChatCommand, Result<ChatDto>>
{
    public async Task<Result<ChatDto>> Handle(CreateChatCommand request, CancellationToken ct)
    {
        var entity = new Chat { CustomerId = request.CustomerId, RealtorId = request.RealtorId };
        var created = await repository.AddAsync(entity, ct);
        return ChatMappings.MapToDto(created);
    }
}
