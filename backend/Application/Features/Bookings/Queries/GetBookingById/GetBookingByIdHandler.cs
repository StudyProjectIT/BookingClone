using Application.DTOs;
using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Bookings.Queries.GetBookingById;

public class GetBookingByIdHandler(IBookingRepository bookingRepository)
    : IRequestHandler<GetBookingByIdQuery, Result<BookingDto>>
{
    public async Task<Result<BookingDto>> Handle(GetBookingByIdQuery request, CancellationToken ct)
    {
        var booking = await bookingRepository.GetByIdAsync(request.Id);
        if (booking is null)
            return Error.NotFound($"Booking with id {request.Id} not found.");

        return BookingMappings.MapToDto(booking);
    }
}
