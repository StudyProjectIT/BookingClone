using Core.Entities;

namespace Core.Interfaces;

public interface IBookingRepository
{
    Task<IReadOnlyList<Booking>> GetByUserIdAsync(string userId);
    Task<Booking?> GetByIdAsync(int id);
    Task<Booking> AddAsync(Booking booking);
    Task DeleteAsync(int id);
}
