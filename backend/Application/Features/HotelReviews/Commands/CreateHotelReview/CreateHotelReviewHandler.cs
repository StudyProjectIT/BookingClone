using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelReviews.Commands.CreateHotelReview;

public class CreateHotelReviewHandler(IRepository<HotelReview> repository)
    : IRequestHandler<CreateHotelReviewCommand, Result<HotelReviewDto>>
{
    public async Task<Result<HotelReviewDto>> Handle(CreateHotelReviewCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Description))
            return Error.Validation("Review description is required.");

        var entity = new HotelReview
        {
            Description = request.Description,
            Score = request.Score,
            BookingId = request.BookingId,
            CreatedAtUtc = DateTime.UtcNow
        };
        var created = await repository.AddAsync(entity, ct);
        return HotelReviewMappings.MapToDto(created);
    }
}
