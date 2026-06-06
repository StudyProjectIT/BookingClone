using Domain.Entities;

namespace Domain.Interfaces;

public interface IRoomRepository
{
    Task<IReadOnlyList<Room>> GetByHotelIdAsync(long hotelId, CancellationToken ct = default);
    Task<Room?> GetByIdAsync(long id, CancellationToken ct = default);
    Task<Room> AddAsync(Room room, CancellationToken ct = default);
    Task UpdateAsync(Room room, CancellationToken ct = default);
    Task DeleteAsync(long id, CancellationToken ct = default);
}
