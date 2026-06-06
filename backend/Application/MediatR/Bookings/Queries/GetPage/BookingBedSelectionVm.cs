using Application.Common.Mappings;
using Domain.Entities;

namespace Application.MediatR.Bookings.Queries.GetPage;

public class BookingBedSelectionVm : IMapWith<BookingBedSelection> {
	public bool IsSingleBed { get; set; }

	public bool IsDoubleBed { get; set; }

	public bool IsExtraBed { get; set; }

	public bool IsSofa { get; set; }

	public bool IsKingsizeBed { get; set; }
}
