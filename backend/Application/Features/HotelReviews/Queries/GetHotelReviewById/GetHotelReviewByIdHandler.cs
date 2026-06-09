using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelReviews.Queries.GetHotelReviewById;

public class GetHotelReviewByIdHandler(IRepository<HotelReview> repository)
    : IRequestHandler<GetHotelReviewByIdQuery, Result<HotelReviewDto>>
{
    public async Task<Result<HotelReviewDto>> Handle(GetHotelReviewByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Hotel review with id {request.Id} not found.");
        return HotelReviewMappings.MapToDto(entity);
    }
}
