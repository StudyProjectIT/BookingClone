using Application.DTOs;
using Domain.Common;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RealtorReviews.Queries.GetRealtorReviewsByRealtorId;

public class GetRealtorReviewsByRealtorIdHandler(IRealtorReviewRepository repository)
    : IRequestHandler<GetRealtorReviewsByRealtorIdQuery, Result<IReadOnlyList<RealtorReviewDto>>>
{
    public async Task<Result<IReadOnlyList<RealtorReviewDto>>> Handle(GetRealtorReviewsByRealtorIdQuery request, CancellationToken ct)
    {
        var reviews = await repository.GetByRealtorIdAsync(request.RealtorId, ct);
        return reviews.Select(RealtorReviewMappings.MapToDto).ToList().AsReadOnly();
    }
}
