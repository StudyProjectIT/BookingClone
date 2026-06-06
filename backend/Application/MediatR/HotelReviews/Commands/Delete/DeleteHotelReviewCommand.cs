using MediatR;

namespace Application.MediatR.HotelReviews.Commands.Delete;

public class DeleteHotelReviewCommand : IRequest {
	public long Id { get; set; }
}
