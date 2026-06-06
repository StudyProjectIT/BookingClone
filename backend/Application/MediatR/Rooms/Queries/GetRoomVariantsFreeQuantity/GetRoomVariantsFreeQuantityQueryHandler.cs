using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.Rooms.Queries.GetRoomVariantsFreeQuantity;

public class GetRoomVariantsFreeQuantityQueryHandler(
	IBookingDbContext context
) : IRequestHandler<GetRoomVariantsFreeQuantityQuery, int> {

	public async Task<int> Handle(GetRoomVariantsFreeQuantityQuery request, CancellationToken cancellationToken) {
		var period = request.FreePeriod;

		var quantity = await context.Rooms
			.Where(r => r.Id == request.Id)
			.Select(r => (int?)(r.Quantity - r.RoomVariants
				.SelectMany(rv => rv.BookingRoomVariants)
				.Where(brv => (period.From <= brv.Booking.DateTo) && (period.To >= brv.Booking.DateFrom))
				.Sum(brv => brv.Quantity))
			)
			.FirstOrDefaultAsync(cancellationToken)
			?? throw new NotFoundException(nameof(Room), request.Id);

		return Math.Max(quantity, 0);
	}
}
