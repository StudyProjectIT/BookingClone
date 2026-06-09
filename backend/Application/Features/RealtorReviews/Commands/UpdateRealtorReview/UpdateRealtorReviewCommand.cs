using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RealtorReviews.Commands.UpdateRealtorReview;

public record UpdateRealtorReviewCommand(long Id, string Description, double? Score) : IRequest<Result<RealtorReviewDto>>;
