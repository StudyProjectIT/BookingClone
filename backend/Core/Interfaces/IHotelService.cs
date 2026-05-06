using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelDto>> GetAllHotelsAsync();
        Task<HotelDto> CreateHotelAsync(HotelDto createHotelDto);

        Task<HotelDto?> GetHotelByIdAsync(int id);
        Task<bool> UpdateHotelAsync(int id, HotelDto hotelDto);
        Task<bool> DeleteHotelAsync(int id);
    }
}
