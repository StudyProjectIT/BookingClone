using Domain.Common;
using MediatR;

namespace Application.Features.HotelReviews.Commands.DeleteHotelReview;

public record DeleteHotelReviewCommand(long Id) : IRequest<Result<bool>>;
