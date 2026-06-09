using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.RealtorReviews.Commands.DeleteRealtorReview;

public class DeleteRealtorReviewHandler(IRepository<RealtorReview> repository)
    : IRequestHandler<DeleteRealtorReviewCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteRealtorReviewCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Realtor review with id {request.Id} not found.");
        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
