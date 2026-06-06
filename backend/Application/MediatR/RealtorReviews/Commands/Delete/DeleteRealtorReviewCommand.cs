using MediatR;

namespace Application.MediatR.RealtorReviews.Commands.Delete;

public class DeleteRealtorReviewCommand : IRequest {
	public long Id { get; set; }
}
