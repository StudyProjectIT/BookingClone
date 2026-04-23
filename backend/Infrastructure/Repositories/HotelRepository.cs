using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class HotelRepository(AppDbContext context) : IHotelRepository
{
    public async Task<IReadOnlyList<Hotel>> GetAllAsync() =>
        await context.Hotels.ToListAsync();

    public async Task<Hotel?> GetByIdAsync(int id) =>
        await context.Hotels.FindAsync(id);

    public async Task<Hotel> AddAsync(Hotel hotel)
    {
        context.Hotels.Add(hotel);
        await context.SaveChangesAsync();
        return hotel;
    }

    public async Task UpdateAsync(Hotel hotel)
    {
        context.Hotels.Update(hotel);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var hotel = await context.Hotels.FindAsync(id);
        if (hotel is not null)
        {
            context.Hotels.Remove(hotel);
            await context.SaveChangesAsync();
        }
    }
}
