using Application.DTOs;
using Domain.Common;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelReviews.Queries.GetHotelReviewsByHotelId;

public class GetHotelReviewsByHotelIdHandler(IHotelReviewRepository repository)
    : IRequestHandler<GetHotelReviewsByHotelIdQuery, Result<IReadOnlyList<HotelReviewDto>>>
{
    public async Task<Result<IReadOnlyList<HotelReviewDto>>> Handle(GetHotelReviewsByHotelIdQuery request, CancellationToken ct)
    {
        var reviews = await repository.GetByHotelIdAsync(request.HotelId, ct);
        return reviews.Select(HotelReviewMappings.MapToDto).ToList().AsReadOnly();
    }
}
