using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RealtorReviews.Commands.UpdateRealtorReview;

public class UpdateRealtorReviewHandler(IRepository<RealtorReview> repository)
    : IRequestHandler<UpdateRealtorReviewCommand, Result<RealtorReviewDto>>
{
    public async Task<Result<RealtorReviewDto>> Handle(UpdateRealtorReviewCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Realtor review with id {request.Id} not found.");

        if (string.IsNullOrWhiteSpace(request.Description))
            return Error.Validation("Review description is required.");

        entity.Description = request.Description;
        entity.Score = request.Score;
        entity.UpdatedAtUtc = DateTime.UtcNow;
        await repository.UpdateAsync(entity, ct);
        return RealtorReviewMappings.MapToDto(entity);
    }
}
