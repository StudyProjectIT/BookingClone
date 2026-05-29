using Domain.Common;
using MediatR;

namespace Application.Features.Bookings.Commands.DeleteBooking;

public record DeleteBookingCommand(long Id) : IRequest<Result<bool>>;
