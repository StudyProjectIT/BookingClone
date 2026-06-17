using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IHotelReviewRepository : IRepository<HotelReview>
{
    Task<IReadOnlyList<HotelReview>> GetByHotelIdAsync(long hotelId, CancellationToken ct = default);
}
