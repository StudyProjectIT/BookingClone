using Domain.Entities;

namespace Domain.Interfaces;

public interface IHotelRepository
{
    Task<IReadOnlyList<Hotel>> GetAllAsync(CancellationToken ct = default);
    Task<Hotel?> GetByIdAsync(long id, CancellationToken ct = default);
    Task<Hotel> AddAsync(Hotel hotel, CancellationToken ct = default);
    Task UpdateAsync(Hotel hotel, CancellationToken ct = default);
    Task DeleteAsync(long id, CancellationToken ct = default);
}
