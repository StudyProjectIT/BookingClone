using Application.DTOs;
using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Bookings.Queries.GetAllBookings;

public class GetAllBookingsHandler(IBookingRepository bookingRepository)
    : IRequestHandler<GetAllBookingsQuery, Result<PagedResult<BookingDto>>>
{
    public async Task<Result<PagedResult<BookingDto>>> Handle(GetAllBookingsQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await bookingRepository.GetPagedByCustomerIdAsync(request.CustomerId, request.Page, request.PageSize, ct);
        return new PagedResult<BookingDto>
        {
            Items = items.Select(BookingMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
