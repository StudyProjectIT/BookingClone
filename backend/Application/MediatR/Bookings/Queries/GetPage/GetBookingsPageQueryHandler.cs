using Application.Interfaces;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.Bookings.Queries.GetPage;

public class GetBookingsPageQueryHandler(
	IPaginationService<BookingVm, GetBookingsPageQuery> pagination
) : IRequestHandler<GetBookingsPageQuery, PageVm<BookingVm>> {

	public Task<PageVm<BookingVm>> Handle(GetBookingsPageQuery request, CancellationToken cancellationToken) =>
		pagination.GetPageAsync(request, cancellationToken);
}
