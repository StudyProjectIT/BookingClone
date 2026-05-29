using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Bookings.Commands.UpdateBooking;

public record UpdateBookingCommand(
    long Id,
    long RoomVariantId,
    int Quantity,
    DateTime CheckIn,
    DateTime CheckOut,
    decimal TotalPrice,
    string? PersonalWishes
) : IRequest<Result<BookingDto>>;
