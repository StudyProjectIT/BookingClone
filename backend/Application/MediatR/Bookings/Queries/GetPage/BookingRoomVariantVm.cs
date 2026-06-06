using Application.Common.Mappings;
using Application.MediatR.RoomVariants.Queries.Shared;
using Domain.Entities;

namespace Application.MediatR.Bookings.Queries.GetPage;

public class BookingRoomVariantVm : IMapWith<BookingRoomVariant> {
	public long Id { get; set; }

	public int Quantity { get; set; }

	public long RoomVariantId { get; set; }
	public RoomVariantVm RoomVariant { get; set; } = null!;

	public BookingBedSelectionVm BookingBedSelection { get; set; } = null!;
}
