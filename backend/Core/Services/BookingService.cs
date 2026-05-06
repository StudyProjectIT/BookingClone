using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class BookingService(IBookingRepository bookingRepository, IHotelRepository hotelRepository) : IBookingService
    {
        public async Task<IReadOnlyList<Booking>> GetAllAsync()
        {
            return await bookingRepository.GetAllAsync();
        }

        public async Task<IReadOnlyList<Booking>> GetByHotelIdAsync(int hotelId)
        {
            return await bookingRepository.GetByHotelIdAsync(hotelId);
        }

        public async Task<IReadOnlyList<Booking>> GetByUserIdAsync(int userId)
        {
            return await bookingRepository.GetByUserIdAsync(userId.ToString());
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await bookingRepository.GetByIdAsync(id);
        }

        public async Task<Booking> AddAsync(Booking booking)
        {
            if (booking.CheckIn >= booking.CheckOut)
                throw new ArgumentException("date error");
            var hotel = await hotelRepository.GetByIdAsync(booking.HotelId);
            if (hotel == null)
                throw new ArgumentException("hotel error");

            var existingBookings = await bookingRepository.GetByHotelIdAsync(booking.HotelId);
            bool isOverlap = existingBookings.Any(b =>
                booking.CheckIn < b.CheckOut && booking.CheckOut > b.CheckIn);

            if (isOverlap)
                throw new ArgumentException("dates unavailable");

            int nights = (booking.CheckOut.Date - booking.CheckIn.Date).Days;
            booking.TotalPrice = nights * hotel.PricePerNight;
            booking.CreatedAt = DateTime.UtcNow;
            return await bookingRepository.AddAsync(booking);
        }

        public async Task UpdateAsync(Booking booking)
        {
            var existingBooking = await bookingRepository.GetByIdAsync(booking.Id);
            if (existingBooking == null)
                throw new ArgumentException("booking not found");

            await bookingRepository.UpdateAsync(booking);
        }

        public async Task DeleteAsync(int id)
        {
            await bookingRepository.DeleteAsync(id);
        }
    }
}