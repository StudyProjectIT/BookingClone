using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Bookings.Queries.GetAllBookingsAdmin;

public record GetAllBookingsAdminQuery(int Page, int PageSize) : IRequest<Result<PagedResult<BookingDto>>>;
