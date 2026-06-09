using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelReviews.Queries.GetHotelReviewById;

public record GetHotelReviewByIdQuery(long Id) : IRequest<Result<HotelReviewDto>>;
