using Application.DTOs;
using Domain.Entities;

namespace Application.Features.RealtorReviews;

internal static class RealtorReviewMappings
{
    internal static RealtorReviewDto MapToDto(RealtorReview e) => new()
    {
        Id = e.Id,
        Description = e.Description,
        Score = e.Score,
        AuthorId = e.AuthorId,
        RealtorId = e.RealtorId,
        CreatedAtUtc = e.CreatedAtUtc,
        UpdatedAtUtc = e.UpdatedAtUtc
    };
}
