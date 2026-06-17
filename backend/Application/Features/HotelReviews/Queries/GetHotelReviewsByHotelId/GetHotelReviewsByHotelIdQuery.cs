using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelReviews.Queries.GetHotelReviewsByHotelId;

public record GetHotelReviewsByHotelIdQuery(long HotelId) : IRequest<Result<IReadOnlyList<HotelReviewDto>>>;
