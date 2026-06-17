using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IRealtorReviewRepository : IRepository<RealtorReview>
{
    Task<IReadOnlyList<RealtorReview>> GetByRealtorIdAsync(long realtorId, CancellationToken ct = default);
}
