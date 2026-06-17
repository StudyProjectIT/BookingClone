using Application.DTOs;
using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Bookings.Queries.GetBookingsByHotelId;

public class GetBookingsByHotelIdHandler(IBookingRepository bookingRepository)
    : IRequestHandler<GetBookingsByHotelIdQuery, Result<IReadOnlyList<BookingDto>>>
{
    public async Task<Result<IReadOnlyList<BookingDto>>> Handle(GetBookingsByHotelIdQuery request, CancellationToken ct)
    {
        var bookings = await bookingRepository.GetByHotelIdAsync(request.HotelId, ct);
        return bookings.Select(BookingMappings.MapToDto).ToList().AsReadOnly();
    }
}
