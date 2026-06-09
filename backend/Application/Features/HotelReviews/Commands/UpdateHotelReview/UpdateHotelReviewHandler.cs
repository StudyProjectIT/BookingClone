using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelReviews.Commands.UpdateHotelReview;

public class UpdateHotelReviewHandler(IRepository<HotelReview> repository)
    : IRequestHandler<UpdateHotelReviewCommand, Result<HotelReviewDto>>
{
    public async Task<Result<HotelReviewDto>> Handle(UpdateHotelReviewCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Hotel review with id {request.Id} not found.");

        if (string.IsNullOrWhiteSpace(request.Description))
            return Error.Validation("Review description is required.");

        entity.Description = request.Description;
        entity.Score = request.Score;
        entity.UpdatedAtUtc = DateTime.UtcNow;
        await repository.UpdateAsync(entity, ct);
        return HotelReviewMappings.MapToDto(entity);
    }
}
