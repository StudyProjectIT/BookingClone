using Application.DTOs;
using Domain.Common;

namespace Application.Interfaces;

public interface IBookingService
{
    Task<Result<IReadOnlyList<BookingDto>>> GetAllAsync(CancellationToken ct = default);
    Task<Result<BookingDto>> GetByIdAsync(long id, CancellationToken ct = default);
    Task<Result<BookingDto>> CreateAsync(CreateBookingDto dto, long customerId, CancellationToken ct = default);
    Task<Result<BookingDto>> UpdateAsync(long id, CreateBookingDto dto, CancellationToken ct = default);
    Task<Result<bool>> DeleteAsync(long id, CancellationToken ct = default);
}
