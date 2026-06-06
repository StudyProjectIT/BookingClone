using Application.MediatR.HotelReviews.Queries.Shared;
using MediatR;

namespace Application.MediatR.HotelReviews.Queries.GetDetails;

public class GetHotelReviewDetalisQuery : IRequest<HotelReviewVm> {
	public long Id { get; set; }
}
