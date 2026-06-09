using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelReviews.Commands.CreateHotelReview;

public record CreateHotelReviewCommand(string Description, double? Score, long BookingId) : IRequest<Result<HotelReviewDto>>;
