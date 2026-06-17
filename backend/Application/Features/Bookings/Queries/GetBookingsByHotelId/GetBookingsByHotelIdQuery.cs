using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Bookings.Queries.GetBookingsByHotelId;

public record GetBookingsByHotelIdQuery(long HotelId) : IRequest<Result<IReadOnlyList<BookingDto>>>;
