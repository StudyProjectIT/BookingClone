using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FavoriteHotelRepository(AppDbContext context) : IFavoriteHotelRepository
{
    public async Task<IReadOnlyList<FavoriteHotel>> GetByCustomerIdAsync(long customerId, CancellationToken ct = default) =>
        (await context.FavoriteHotels
            .Where(f => f.CustomerId == customerId)
            .ToListAsync(ct))
            .AsReadOnly();

    public async Task AddAsync(FavoriteHotel entity, CancellationToken ct = default)
    {
        context.FavoriteHotels.Add(entity);
        await context.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(long customerId, long hotelId, CancellationToken ct = default)
    {
        var entity = await context.FavoriteHotels
            .FirstOrDefaultAsync(f => f.CustomerId == customerId && f.HotelId == hotelId, ct);
        if (entity is not null)
        {
            context.FavoriteHotels.Remove(entity);
            await context.SaveChangesAsync(ct);
        }
    }
}
