using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookingRepository(AppDbContext context) : IBookingRepository
{
    public async Task<IReadOnlyList<Booking>> GetByUserIdAsync(string userId) =>
        await context.Bookings
            .Include(b => b.Hotel)
            .Where(b => b.UserId == userId)
            .ToListAsync();

    public async Task<Booking?> GetByIdAsync(int id) =>
        await context.Bookings.Include(b => b.Hotel).FirstOrDefaultAsync(b => b.Id == id);

    public async Task<Booking> AddAsync(Booking booking)
    {
        context.Bookings.Add(booking);
        await context.SaveChangesAsync();
        return booking;
    }

    public async Task DeleteAsync(int id)
    {
        var booking = await context.Bookings.FindAsync(id);
        if (booking is not null)
        {
            context.Bookings.Remove(booking);
            await context.SaveChangesAsync();
        }
    }
}
