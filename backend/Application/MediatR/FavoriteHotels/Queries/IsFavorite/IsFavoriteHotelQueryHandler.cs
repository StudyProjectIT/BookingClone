using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.FavoriteHotels.Queries.IsFavorite;

public class IsFavoriteHotelQueryHandler(
	IBookingDbContext context,
	ICurrentUserService currentUserService
) : IRequestHandler<IsFavoriteHotelQuery, bool> {

	public Task<bool> Handle(IsFavoriteHotelQuery request, CancellationToken cancellationToken) =>
		context.FavoriteHotels
			.Where(fh => fh.HotelId == request.HotelId && fh.CustomerId == currentUserService.GetRequiredUserId())
			.AnyAsync(cancellationToken);
}
