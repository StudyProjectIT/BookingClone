using Application.DTOs;
using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Bookings.Queries.GetAllBookings;

public class GetAllBookingsHandler(IBookingRepository bookingRepository)
    : IRequestHandler<GetAllBookingsQuery, Result<IReadOnlyList<BookingDto>>>
{
    public async Task<Result<IReadOnlyList<BookingDto>>> Handle(GetAllBookingsQuery request, CancellationToken ct)
    {
        var bookings = await bookingRepository.GetByCustomerIdAsync(request.CustomerId);
        IReadOnlyList<BookingDto> dtos = bookings.Select(BookingMappings.MapToDto).ToList();
        return Result<IReadOnlyList<BookingDto>>.Success(dtos);
    }
}
