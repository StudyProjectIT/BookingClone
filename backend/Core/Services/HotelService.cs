using Core.DTOs;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class HotelService(IHotelRepository hotelRepository) : IHotelService
    {
        public async Task<HotelDto> CreateHotelAsync(HotelDto createHotelDto)
        {
            var hotel = new Core.Entities.Hotel
            {
                Name = createHotelDto.Name,
                Description = createHotelDto.Description,
                Location = createHotelDto.Location,
                PricePerNight = createHotelDto.PricePerNight,
                MaxGuests = createHotelDto.MaxGuests
            };
            var createdHotel = await hotelRepository.AddAsync(hotel);
            return new HotelDto
            {
                Id = createdHotel.Id,
                Name = createdHotel.Name,
                Description = createdHotel.Description,
                Location = createdHotel.Location,
                PricePerNight = createdHotel.PricePerNight,
                MaxGuests = createdHotel.MaxGuests
            };
        }
        public async Task<IEnumerable<HotelDto>> GetAllHotelsAsync()
        {
            var hotels = await hotelRepository.GetAllAsync();

            return hotels.Select(h => new HotelDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                Location = h.Location,
                PricePerNight = h.PricePerNight,
                MaxGuests = h.MaxGuests
            });
        }
        public async Task<HotelDto?> GetHotelByIdAsync(int id)
        {
            var hotel = await hotelRepository.GetByIdAsync(id);
            if (hotel == null) return null;

            return new HotelDto
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Description = hotel.Description,
                Location = hotel.Location,
                PricePerNight = hotel.PricePerNight,
                MaxGuests = hotel.MaxGuests
            };
        }
        public async Task<bool> UpdateHotelAsync(int id, HotelDto hotelDto)
        {
            var hotel = await hotelRepository.GetByIdAsync(id);
            if (hotel == null) return false;

            hotel.Name = hotelDto.Name;
            hotel.Description = hotelDto.Description;
            hotel.Location = hotelDto.Location;
            hotel.PricePerNight = hotelDto.PricePerNight;
            hotel.MaxGuests = hotelDto.MaxGuests;

            await hotelRepository.UpdateAsync(hotel);
            return true;
        }
        public async Task<bool> DeleteHotelAsync(int id)
        {
            var hotel = await hotelRepository.GetByIdAsync(id);
            if (hotel == null) return false;

            await hotelRepository.DeleteAsync(id);
            return true;
        }
    }
}
