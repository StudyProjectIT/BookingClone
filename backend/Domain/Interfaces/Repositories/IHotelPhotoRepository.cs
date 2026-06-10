using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IHotelPhotoRepository : IRepository<HotelPhoto>
{
    Task<IReadOnlyList<HotelPhoto>> GetByHotelIdAsync(long hotelId, CancellationToken ct = default);
}
