using Application.DTOs;
using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class HotelService(IHotelRepository hotelRepository) : IHotelService
{
    public async Task<Result<IReadOnlyList<HotelDto>>> GetAllHotelsAsync(CancellationToken ct = default)
    {
        var hotels = await hotelRepository.GetAllAsync();
        IReadOnlyList<HotelDto> dtos = hotels.Select(MapToDto).ToList();
        return Result<IReadOnlyList<HotelDto>>.Success(dtos);
    }

    public async Task<Result<HotelDto>> GetHotelByIdAsync(int id, CancellationToken ct = default)
    {
        var hotel = await hotelRepository.GetByIdAsync(id);
        if (hotel is null)
            return Error.NotFound($"Hotel with id {id} not found.");

        return MapToDto(hotel);
    }

    public async Task<Result<HotelDto>> CreateHotelAsync(HotelDto dto, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return Error.Validation("Hotel name is required.");

        var hotel = new Hotel
        {
            Name = dto.Name,
            Description = dto.Description,
            IsArchived = false
        };

        var created = await hotelRepository.AddAsync(hotel);
        return MapToDto(created);
    }

    public async Task<Result<HotelDto>> UpdateHotelAsync(int id, HotelDto dto, CancellationToken ct = default)
    {
        var hotel = await hotelRepository.GetByIdAsync(id);
        if (hotel is null)
            return Error.NotFound($"Hotel with id {id} not found.");

        if (string.IsNullOrWhiteSpace(dto.Name))
            return Error.Validation("Hotel name is required.");

        hotel.Name = dto.Name;
        hotel.Description = dto.Description;

        await hotelRepository.UpdateAsync(hotel);
        return MapToDto(hotel);
    }

    public async Task<Result<bool>> DeleteHotelAsync(int id, CancellationToken ct = default)
    {
        var hotel = await hotelRepository.GetByIdAsync(id);
        if (hotel is null)
            return Error.NotFound($"Hotel with id {id} not found.");

        await hotelRepository.DeleteAsync(id);
        return true;
    }

    private static HotelDto MapToDto(Hotel h) => new()
    {
        Id = (int)h.Id,
        Name = h.Name,
        Description = h.Description
    };
}
