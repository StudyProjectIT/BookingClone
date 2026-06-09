using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RealtorReviews.Commands.CreateRealtorReview;

public class CreateRealtorReviewHandler(IRepository<RealtorReview> repository)
    : IRequestHandler<CreateRealtorReviewCommand, Result<RealtorReviewDto>>
{
    public async Task<Result<RealtorReviewDto>> Handle(CreateRealtorReviewCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Description))
            return Error.Validation("Review description is required.");

        var entity = new RealtorReview
        {
            Description = request.Description,
            Score = request.Score,
            AuthorId = request.AuthorId,
            RealtorId = request.RealtorId,
            CreatedAtUtc = DateTime.UtcNow
        };
        var created = await repository.AddAsync(entity, ct);
        return RealtorReviewMappings.MapToDto(created);
    }
}
