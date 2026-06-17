using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.HotelReviews.Commands.DeleteHotelReview;

public class DeleteHotelReviewHandler(
    IRepository<HotelReview> repository,
    IBookingRepository bookingRepository,
    ICurrentUserService currentUser)
    : IRequestHandler<DeleteHotelReviewCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteHotelReviewCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Hotel review with id {request.Id} not found.");

        var booking = await bookingRepository.GetByIdAsync(entity.BookingId);
        if (booking is null || booking.CustomerId != currentUser.GetUserId())
            return Error.Forbidden("You do not have access to this resource.");

        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
