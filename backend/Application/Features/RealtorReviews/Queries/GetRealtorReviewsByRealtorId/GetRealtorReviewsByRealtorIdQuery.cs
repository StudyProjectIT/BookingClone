using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RealtorReviews.Queries.GetRealtorReviewsByRealtorId;

public record GetRealtorReviewsByRealtorIdQuery(long RealtorId) : IRequest<Result<IReadOnlyList<RealtorReviewDto>>>;
