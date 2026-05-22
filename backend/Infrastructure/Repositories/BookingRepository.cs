using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class BookingRepository(AppDbContext context) : IBookingRepository
{
    public async Task<IReadOnlyList<Booking>> GetAllAsync()
    {
        var bookings = await context.Bookings.ToListAsync();
        return bookings.AsReadOnly();
    }

    public async Task<IReadOnlyList<Booking>> GetByHotelIdAsync(long hotelId)
    {
        var bookings = await context.BookingRoomVariants
            .Where(brv => brv.RoomVariant.Room.HotelId == hotelId)
            .Select(brv => brv.Booking)
            .Distinct()
            .ToListAsync();
        return bookings.AsReadOnly();
    }

    public async Task<IReadOnlyList<Booking>> GetByUserIdAsync(string userId)
    {
        var bookings = await context.Bookings.ToListAsync();
        return bookings.AsReadOnly();
    }

    public async Task<Booking?> GetByIdAsync(long id)
    {
        return await context.Bookings.FindAsync(id);
    }

    public async Task<Booking> AddAsync(Booking booking)
    {
        context.Bookings.Add(booking);
        await context.SaveChangesAsync();
        return booking;
    }

    public async Task UpdateAsync(Booking booking)
    {
        context.Bookings.Update(booking);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var booking = await context.Bookings.FindAsync(id);
        if (booking != null)
        {
            context.Bookings.Remove(booking);
            await context.SaveChangesAsync();
        }
    }
}