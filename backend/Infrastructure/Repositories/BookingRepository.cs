//using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

//public class BookingRepository(AppDbContext context) : IBookingRepository
//{
//    public async Task<IReadOnlyList<Booking>> GetAllAsync()
//    {
//        return await context.Bookings.ToListAsync();
//    }
//    public async Task<IReadOnlyList<Booking>> GetByHotelIdAsync(int hotelId)
//    {
//        return await context.Bookings.Where(b => b.HotelId == hotelId).ToListAsync();
//    }
//    public async Task<IReadOnlyList<Booking>> GetByUserIdAsync(string userId)
//    {
//        return await context.Bookings.Where(b => b.UserId == userId).ToListAsync();
//    }
//    public async Task<Booking?> GetByIdAsync(int id)
//    {
//        return await context.Bookings.FindAsync(id);
//    }
//    public async Task<Booking> AddAsync(Booking booking)
//    {
//        context.Bookings.Add(booking);
//        await context.SaveChangesAsync();
//        return booking;
//    }
//    public async Task UpdateAsync(Booking booking)
//    {
//        context.Bookings.Update(booking);
//        await context.SaveChangesAsync();
//    }
//    public async Task DeleteAsync(int id)
//    {
//        var booking = await context.Bookings.FindAsync(id);
//        if (booking != null)
//        {
//            context.Bookings.Remove(booking);
//            await context.SaveChangesAsync();
//        }
//    }
//}