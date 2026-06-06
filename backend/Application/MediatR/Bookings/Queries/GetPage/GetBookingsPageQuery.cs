using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.Bookings.Queries.GetPage;

public class GetBookingsPageQuery : PaginationFilterDto, IRequest<PageVm<BookingVm>> {
	public string? OrderBy { get; set; }
}
