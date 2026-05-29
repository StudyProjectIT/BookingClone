using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Bookings.Queries.GetBookingById;

public record GetBookingByIdQuery(long Id) : IRequest<Result<BookingDto>>;
