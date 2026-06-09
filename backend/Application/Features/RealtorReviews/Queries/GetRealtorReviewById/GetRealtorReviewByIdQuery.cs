using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RealtorReviews.Queries.GetRealtorReviewById;

public record GetRealtorReviewByIdQuery(long Id) : IRequest<Result<RealtorReviewDto>>;
