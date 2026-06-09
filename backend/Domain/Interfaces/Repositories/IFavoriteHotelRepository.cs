using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IFavoriteHotelRepository
{
    Task<IReadOnlyList<FavoriteHotel>> GetByCustomerIdAsync(long customerId, CancellationToken ct = default);
    Task AddAsync(FavoriteHotel entity, CancellationToken ct = default);
    Task RemoveAsync(long customerId, long hotelId, CancellationToken ct = default);
}
