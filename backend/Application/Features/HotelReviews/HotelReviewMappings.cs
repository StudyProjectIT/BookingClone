using Application.DTOs;
using Domain.Entities;

namespace Application.Features.HotelReviews;

internal static class HotelReviewMappings
{
    internal static HotelReviewDto MapToDto(HotelReview e) => new()
    {
        Id = e.Id,
        Description = e.Description,
        Score = e.Score,
        BookingId = e.BookingId,
        CreatedAtUtc = e.CreatedAtUtc,
        UpdatedAtUtc = e.UpdatedAtUtc
    };
}
