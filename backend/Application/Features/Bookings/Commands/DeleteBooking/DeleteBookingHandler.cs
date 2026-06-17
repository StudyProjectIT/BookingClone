using Application.Interfaces;
using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Bookings.Commands.DeleteBooking;

public class DeleteBookingHandler(IBookingRepository bookingRepository, ICurrentUserService currentUser)
    : IRequestHandler<DeleteBookingCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteBookingCommand request, CancellationToken ct)
    {
        var booking = await bookingRepository.GetByIdAsync(request.Id);
        if (booking is null)
            return Error.NotFound($"Booking with id {request.Id} not found.");

        if (booking.CustomerId != currentUser.GetUserId())
            return Error.Forbidden("You do not have access to this resource.");

        await bookingRepository.DeleteAsync(request.Id);
        return true;
    }
}
