using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Bookings.Queries.GetAllBookings;

public record GetAllBookingsQuery(long CustomerId, int Page, int PageSize) : IRequest<Result<PagedResult<BookingDto>>>;
