using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IChatRepository : IRepository<Chat>
{
    Task<IReadOnlyList<Chat>> GetByCustomerIdAsync(long customerId, CancellationToken ct = default);
}
