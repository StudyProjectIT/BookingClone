using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Bookings.Commands.CreateBooking;

public class CreateBookingHandler(IBookingRepository bookingRepository)
    : IRequestHandler<CreateBookingCommand, Result<BookingDto>>
{
    public async Task<Result<BookingDto>> Handle(CreateBookingCommand request, CancellationToken ct)
    {
        if (request.CheckOut <= request.CheckIn)
            return Error.Validation("CheckOut must be later than CheckIn.");

        var booking = new Booking
        {
            CustomerId = request.CustomerId,
            DateFrom = DateOnly.FromDateTime(request.CheckIn),
            DateTo = DateOnly.FromDateTime(request.CheckOut),
            AmountToPay = request.TotalPrice,
            PersonalWishes = request.PersonalWishes,
            EstimatedTimeOfArrivalUtc = new DateTimeOffset(request.CheckIn, TimeSpan.Zero),
            BookingRoomVariants = new List<BookingRoomVariant>
            {
                new()
                {
                    RoomVariantId = request.RoomVariantId,
                    Quantity = request.Quantity
                }
            }
        };

        var created = await bookingRepository.AddAsync(booking);
        return BookingMappings.MapToDto(created);
    }
}
