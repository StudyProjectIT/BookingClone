using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Bookings;

internal static class BookingMappings
{
    internal static BookingDto MapToDto(Booking b) => new()
    {
        Id = (int)b.Id,
        HotelId = (int)(b.BookingRoomVariants.FirstOrDefault()?.RoomVariant?.Room?.HotelId ?? 0),
        UserId = b.Customer?.UserName ?? string.Empty,
        CheckIn = b.DateFrom.ToDateTime(TimeOnly.MinValue),
        CheckOut = b.DateTo.ToDateTime(TimeOnly.MinValue),
        Guests = b.BookingRoomVariants.Sum(brv => brv.Quantity),
        TotalPrice = b.AmountToPay,
        Status = b.Status.ToString(),
        CancelledAtUtc = b.CancelledAtUtc,
        ConfirmedAtUtc = b.ConfirmedAtUtc
    };
}
