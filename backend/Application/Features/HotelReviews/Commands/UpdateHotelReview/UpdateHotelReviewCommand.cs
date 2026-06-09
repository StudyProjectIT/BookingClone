using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelReviews.Commands.UpdateHotelReview;

public record UpdateHotelReviewCommand(long Id, string Description, double? Score) : IRequest<Result<HotelReviewDto>>;
