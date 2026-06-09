using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RealtorReviews.Commands.CreateRealtorReview;

public record CreateRealtorReviewCommand(string Description, double? Score, long AuthorId, long RealtorId) : IRequest<Result<RealtorReviewDto>>;
