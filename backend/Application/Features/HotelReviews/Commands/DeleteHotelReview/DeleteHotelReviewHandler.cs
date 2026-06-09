using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelReviews.Commands.DeleteHotelReview;

public class DeleteHotelReviewHandler(IRepository<HotelReview> repository)
    : IRequestHandler<DeleteHotelReviewCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteHotelReviewCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Hotel review with id {request.Id} not found.");
        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
