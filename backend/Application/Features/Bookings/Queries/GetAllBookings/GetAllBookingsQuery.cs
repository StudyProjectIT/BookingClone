using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Bookings.Queries.GetAllBookings;

public record GetAllBookingsQuery(long CustomerId) : IRequest<Result<IReadOnlyList<BookingDto>>>;
