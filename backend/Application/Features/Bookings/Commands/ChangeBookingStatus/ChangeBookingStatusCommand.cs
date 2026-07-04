using Application.DTOs;
using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Bookings.Commands.ChangeBookingStatus;

public record ChangeBookingStatusCommand(long BookingId, BookingStatus NewStatus) : IRequest<Result<BookingDto>>;
