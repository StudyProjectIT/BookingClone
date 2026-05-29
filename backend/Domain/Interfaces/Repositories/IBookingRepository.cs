using Domain.Entities;

namespace Domain.Interfaces;

public interface IBookingRepository
{
    Task<IReadOnlyList<Booking>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Booking>> GetByCustomerIdAsync(long customerId, CancellationToken ct = default);
    Task<IReadOnlyList<Booking>> GetByHotelIdAsync(long hotelId, CancellationToken ct = default);
    Task<Booking?> GetByIdAsync(long id, CancellationToken ct = default);
    Task<Booking> AddAsync(Booking booking, CancellationToken ct = default);
    Task UpdateAsync(Booking booking, CancellationToken ct = default);
    Task DeleteAsync(long id, CancellationToken ct = default);
}
