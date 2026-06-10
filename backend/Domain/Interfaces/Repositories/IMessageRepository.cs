using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IMessageRepository : IRepository<Message>
{
    Task<IReadOnlyList<Message>> GetByChatIdAsync(long chatId, CancellationToken ct = default);
}
