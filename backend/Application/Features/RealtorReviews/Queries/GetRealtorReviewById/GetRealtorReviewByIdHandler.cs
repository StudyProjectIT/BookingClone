using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RealtorReviews.Queries.GetRealtorReviewById;

public class GetRealtorReviewByIdHandler(IRepository<RealtorReview> repository)
    : IRequestHandler<GetRealtorReviewByIdQuery, Result<RealtorReviewDto>>
{
    public async Task<Result<RealtorReviewDto>> Handle(GetRealtorReviewByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Realtor review with id {request.Id} not found.");
        return RealtorReviewMappings.MapToDto(entity);
    }
}
