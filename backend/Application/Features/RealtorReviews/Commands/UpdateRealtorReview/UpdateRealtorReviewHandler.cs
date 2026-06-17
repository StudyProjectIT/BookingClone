using Application.DTOs;
using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RealtorReviews.Commands.UpdateRealtorReview;

public class UpdateRealtorReviewHandler(IRepository<RealtorReview> repository, ICurrentUserService currentUser)
    : IRequestHandler<UpdateRealtorReviewCommand, Result<RealtorReviewDto>>
{
    public async Task<Result<RealtorReviewDto>> Handle(UpdateRealtorReviewCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Realtor review with id {request.Id} not found.");

        if (entity.AuthorId != currentUser.GetUserId())
            return Error.Forbidden("You do not have access to this resource.");

        entity.Description = request.Description;
        entity.Score = request.Score;
        entity.UpdatedAtUtc = DateTime.UtcNow;
        await repository.UpdateAsync(entity, ct);
        return RealtorReviewMappings.MapToDto(entity);
    }
}
