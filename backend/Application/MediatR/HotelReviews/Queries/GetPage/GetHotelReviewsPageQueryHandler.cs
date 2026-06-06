using Application.Interfaces;
using Application.MediatR.HotelReviews.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.HotelReviews.Queries.GetPage;

public class GetHotelReviewsPageQueryHandler(
	IPaginationService<HotelReviewVm, GetHotelReviewsPageQuery> pagination
) : IRequestHandler<GetHotelReviewsPageQuery, PageVm<HotelReviewVm>> {

	public Task<PageVm<HotelReviewVm>> Handle(GetHotelReviewsPageQuery request, CancellationToken cancellationToken) =>
		pagination.GetPageAsync(request, cancellationToken);
}
