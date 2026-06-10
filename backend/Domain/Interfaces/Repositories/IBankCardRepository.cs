using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IBankCardRepository : IRepository<BankCard>
{
    Task<IReadOnlyList<BankCard>> GetByCustomerIdAsync(long customerId, CancellationToken ct = default);
}
