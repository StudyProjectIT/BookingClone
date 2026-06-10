using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MessageRepository(AppDbContext context) : Repository<Message>(context), IMessageRepository
{
    public async Task<IReadOnlyList<Message>> GetByChatIdAsync(long chatId, CancellationToken ct = default) =>
        (await Context.Messages.Where(m => m.ChatId == chatId).OrderBy(m => m.CreatedAtUtc).ToListAsync(ct)).AsReadOnly();
}
