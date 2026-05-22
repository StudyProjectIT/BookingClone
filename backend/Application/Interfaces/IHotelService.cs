using Application.DTOs;
using Domain.Common;

namespace Application.Interfaces;

public interface IHotelService
{
    Task<Result<IReadOnlyList<HotelDto>>> GetAllHotelsAsync(CancellationToken ct = default);
    Task<Result<HotelDto>> GetHotelByIdAsync(int id, CancellationToken ct = default);
    Task<Result<HotelDto>> CreateHotelAsync(HotelDto dto, CancellationToken ct = default);
    Task<Result<HotelDto>> UpdateHotelAsync(int id, HotelDto dto, CancellationToken ct = default);
    Task<Result<bool>> DeleteHotelAsync(int id, CancellationToken ct = default);
}
