using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class HotelPhotoRepository(AppDbContext context) : Repository<HotelPhoto>(context), IHotelPhotoRepository
{
    public async Task<IReadOnlyList<HotelPhoto>> GetByHotelIdAsync(long hotelId, CancellationToken ct = default) =>
        (await Context.HotelPhotos.Where(p => p.HotelId == hotelId).OrderBy(p => p.Priority).ToListAsync(ct)).AsReadOnly();
}
