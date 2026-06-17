using Application.DTOs;
using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Bookings.Commands.UpdateBooking;

public class UpdateBookingHandler(IBookingRepository bookingRepository, ICurrentUserService currentUser)
    : IRequestHandler<UpdateBookingCommand, Result<BookingDto>>
{
    public async Task<Result<BookingDto>> Handle(UpdateBookingCommand request, CancellationToken ct)
    {
        if (request.CheckOut <= request.CheckIn)
            return Error.Validation("CheckOut must be later than CheckIn.");

        var booking = await bookingRepository.GetByIdAsync(request.Id);
        if (booking is null)
            return Error.NotFound($"Booking with id {request.Id} not found.");

        if (booking.CustomerId != currentUser.GetUserId())
            return Error.Forbidden("You do not have access to this resource.");

        var checkIn = DateOnly.FromDateTime(request.CheckIn);
        var checkOut = DateOnly.FromDateTime(request.CheckOut);

        var available = await bookingRepository.IsRoomVariantAvailableAsync(request.RoomVariantId, checkIn, checkOut, request.Id, ct);
        if (!available)
            return Error.Conflict("Room is not available for selected dates.");

        booking.DateFrom = checkIn;
        booking.DateTo = checkOut;
        booking.AmountToPay = request.TotalPrice;
        booking.PersonalWishes = request.PersonalWishes;

        var existingVariant = booking.BookingRoomVariants.FirstOrDefault();
        if (existingVariant is not null)
        {
            existingVariant.RoomVariantId = request.RoomVariantId;
            existingVariant.Quantity = request.Quantity;
        }
        else
        {
            booking.BookingRoomVariants.Add(new BookingRoomVariant
            {
                RoomVariantId = request.RoomVariantId,
                Quantity = request.Quantity
            });
        }

        await bookingRepository.UpdateAsync(booking);
        return BookingMappings.MapToDto(booking);
    }
}
