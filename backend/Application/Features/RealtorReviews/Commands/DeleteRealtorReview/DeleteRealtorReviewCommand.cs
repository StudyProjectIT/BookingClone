using Domain.Common;
using MediatR;

namespace Application.Features.RealtorReviews.Commands.DeleteRealtorReview;

public record DeleteRealtorReviewCommand(long Id) : IRequest<Result<bool>>;
