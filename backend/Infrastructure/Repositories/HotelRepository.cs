using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class HotelRepository(AppDbContext context) : IHotelRepository
{
    public async Task<IReadOnlyList<Hotel>> GetAllAsync(CancellationToken ct = default)
    {
        return (await context.Hotels
            .Include(h => h.Address)
                .ThenInclude(a => a.City)
            .ToListAsync(ct))
            .AsReadOnly();
    }

    public async Task<Hotel?> GetByIdAsync(long id, CancellationToken ct = default)
    {
        return await context.Hotels
            .Include(h => h.Address)
                .ThenInclude(a => a.City)
            .FirstOrDefaultAsync(h => h.Id == id, ct);
    }

    public async Task<Hotel> AddAsync(Hotel hotel, CancellationToken ct = default)
    {
        context.Hotels.Add(hotel);
        await context.SaveChangesAsync(ct);
        return hotel;
    }

    public async Task UpdateAsync(Hotel hotel, CancellationToken ct = default)
    {
        context.Hotels.Update(hotel);
        await context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(long id, CancellationToken ct = default)
    {
        var hotel = await context.Hotels.FindAsync(new object[] { id }, ct);
        if (hotel is not null)
        {
            context.Hotels.Remove(hotel);
            await context.SaveChangesAsync(ct);
        }
    }
}
