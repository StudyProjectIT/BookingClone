using Application.DTOs;
using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class BookingService(
    IBookingRepository bookingRepository,
    IHotelRepository hotelRepository) : IBookingService
{
    public async Task<Result<IReadOnlyList<BookingDto>>> GetAllAsync(CancellationToken ct = default)
    {
        var bookings = await bookingRepository.GetAllAsync();
        IReadOnlyList<BookingDto> dtos = bookings.Select(MapToDto).ToList();
        return Result<IReadOnlyList<BookingDto>>.Success(dtos);
    }

    public async Task<Result<BookingDto>> GetByIdAsync(long id, CancellationToken ct = default)
    {
        var booking = await bookingRepository.GetByIdAsync(id);
        if (booking is null)
            return Error.NotFound($"Booking with id {id} not found.");
        return MapToDto(booking);
    }

    public async Task<Result<BookingDto>> CreateAsync(CreateBookingDto dto, long customerId, CancellationToken ct = default)
    {
        if (dto.CheckOut <= dto.CheckIn)
            return Error.Validation("CheckOut must be later than CheckIn.");

        var hotel = await hotelRepository.GetByIdAsync(dto.HotelId);
        if (hotel is null)
            return Error.NotFound($"Hotel with id {dto.HotelId} not found.");

        var booking = new Booking
        {
            CustomerId = customerId,
            DateFrom = DateOnly.FromDateTime(dto.CheckIn),
            DateTo = DateOnly.FromDateTime(dto.CheckOut),
            AmountToPay = dto.TotalPrice,
            PersonalWishes = dto.PersonalWishes,
            EstimatedTimeOfArrivalUtc = new DateTimeOffset(dto.CheckIn, TimeSpan.Zero)
        };

        var created = await bookingRepository.AddAsync(booking);
        return MapToDto(created);
    }

    public async Task<Result<BookingDto>> UpdateAsync(long id, CreateBookingDto dto, CancellationToken ct = default)
    {
        if (dto.CheckOut <= dto.CheckIn)
            return Error.Validation("CheckOut must be later than CheckIn.");

        var booking = await bookingRepository.GetByIdAsync(id);
        if (booking is null)
            return Error.NotFound($"Booking with id {id} not found.");

        booking.DateFrom = DateOnly.FromDateTime(dto.CheckIn);
        booking.DateTo = DateOnly.FromDateTime(dto.CheckOut);
        booking.AmountToPay = dto.TotalPrice;
        booking.PersonalWishes = dto.PersonalWishes;

        await bookingRepository.UpdateAsync(booking);
        return MapToDto(booking);
    }

    public async Task<Result<bool>> DeleteAsync(long id, CancellationToken ct = default)
    {
        var booking = await bookingRepository.GetByIdAsync(id);
        if (booking is null)
            return Error.NotFound($"Booking with id {id} not found.");

        await bookingRepository.DeleteAsync(id);
        return true;
    }

    private static BookingDto MapToDto(Booking b) => new()
    {
        Id = (int)b.Id,
        HotelId = (int)b.CustomerId,
        UserId = b.Customer?.UserName ?? string.Empty,
        CheckIn = b.DateFrom.ToDateTime(TimeOnly.MinValue),
        CheckOut = b.DateTo.ToDateTime(TimeOnly.MinValue),
        Guests = 1,
        TotalPrice = b.AmountToPay
    };
}
