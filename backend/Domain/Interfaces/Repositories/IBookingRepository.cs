using Domain.Entities;

namespace Domain.Interfaces;

public interface IBookingRepository
{
    Task<IReadOnlyList<Booking>> GetAllAsync();
    Task<IReadOnlyList<Booking>> GetByHotelIdAsync(long hotelId);
    Task<IReadOnlyList<Booking>> GetByUserIdAsync(string userId);
    Task<Booking?> GetByIdAsync(long id);
    Task<Booking> AddAsync(Booking booking);
    Task UpdateAsync(Booking booking);
    Task DeleteAsync(long id);
}
