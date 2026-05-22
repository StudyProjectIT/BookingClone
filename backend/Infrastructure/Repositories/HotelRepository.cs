using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class HotelRepository(AppDbContext context) : IHotelRepository
{
    public async Task<IReadOnlyList<Hotel>> GetAllAsync()
    {
        var hotels = await context.Hotels.ToListAsync();
        return hotels.AsReadOnly();
    }

    public async Task<Hotel?> GetByIdAsync(long id)
    {
        return await context.Hotels.FindAsync(id);
    }

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

    public async Task DeleteAsync(long id)
    {
        var hotel = await context.Hotels.FindAsync(id);
        if (hotel is not null)
        {
            context.Hotels.Remove(hotel);
            await context.SaveChangesAsync();
        }
    }
}
