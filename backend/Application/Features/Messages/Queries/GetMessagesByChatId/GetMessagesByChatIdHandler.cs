using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Messages.Queries.GetMessagesByChatId;

public class GetMessagesByChatIdHandler(IRepository<Message> repository)
    : IRequestHandler<GetMessagesByChatIdQuery, Result<IReadOnlyList<MessageDto>>>
{
    public async Task<Result<IReadOnlyList<MessageDto>>> Handle(GetMessagesByChatIdQuery request, CancellationToken ct)
    {
        var all = await repository.GetAllAsync(ct);
        return all.Where(m => m.ChatId == request.ChatId)
                  .OrderBy(m => m.CreatedAtUtc)
                  .Select(MessageMappings.MapToDto)
                  .ToList()
                  .AsReadOnly();
    }
}
