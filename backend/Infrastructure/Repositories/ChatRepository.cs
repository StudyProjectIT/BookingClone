using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ChatRepository(AppDbContext context) : Repository<Chat>(context), IChatRepository
{
    public async Task<IReadOnlyList<Chat>> GetByCustomerIdAsync(long customerId, CancellationToken ct = default) =>
        (await Context.Chats.Where(c => c.CustomerId == customerId).ToListAsync(ct)).AsReadOnly();
}
