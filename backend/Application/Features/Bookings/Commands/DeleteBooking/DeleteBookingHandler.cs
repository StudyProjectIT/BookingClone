using Domain.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Bookings.Commands.DeleteBooking;

public class DeleteBookingHandler(IBookingRepository bookingRepository)
    : IRequestHandler<DeleteBookingCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteBookingCommand request, CancellationToken ct)
    {
        var booking = await bookingRepository.GetByIdAsync(request.Id);
        if (booking is null)
            return Error.NotFound($"Booking with id {request.Id} not found.");

        await bookingRepository.DeleteAsync(request.Id);
        return true;
    }
}
