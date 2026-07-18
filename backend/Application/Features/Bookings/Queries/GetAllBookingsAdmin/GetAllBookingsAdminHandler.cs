using Application.DTOs;
using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Bookings.Queries.GetAllBookingsAdmin;

public class GetAllBookingsAdminHandler(IBookingRepository bookingRepository)
    : IRequestHandler<GetAllBookingsAdminQuery, Result<PagedResult<BookingDto>>>
{
    public async Task<Result<PagedResult<BookingDto>>> Handle(GetAllBookingsAdminQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await bookingRepository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<BookingDto>
        {
            Items = items.Select(BookingMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
