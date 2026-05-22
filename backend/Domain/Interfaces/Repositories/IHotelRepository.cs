using Domain.Entities;

namespace Domain.Interfaces;

public interface IHotelRepository
{
    Task<IReadOnlyList<Hotel>> GetAllAsync();
    Task<Hotel?> GetByIdAsync(long id);
    Task<Hotel> AddAsync(Hotel hotel);
    Task UpdateAsync(Hotel hotel);
    Task DeleteAsync(long id);
}
