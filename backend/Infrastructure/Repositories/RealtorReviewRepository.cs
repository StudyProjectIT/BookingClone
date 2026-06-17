using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RealtorReviewRepository(AppDbContext context) : Repository<RealtorReview>(context), IRealtorReviewRepository
{
    public async Task<IReadOnlyList<RealtorReview>> GetByRealtorIdAsync(long realtorId, CancellationToken ct = default) =>
        (await Context.RealtorReviews
            .Where(r => r.RealtorId == realtorId)
            .OrderByDescending(r => r.CreatedAtUtc)
            .ToListAsync(ct))
            .AsReadOnly();
}
