using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BankCardRepository(AppDbContext context) : Repository<BankCard>(context), IBankCardRepository
{
    public async Task<IReadOnlyList<BankCard>> GetByCustomerIdAsync(long customerId, CancellationToken ct = default) =>
        (await Context.BankCards.Where(c => c.CustomerId == customerId).ToListAsync(ct)).AsReadOnly();
}
