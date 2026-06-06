using Application.MediatR.HotelAmenities.Queries.Shared;
using MediatR;

namespace Application.MediatR.HotelAmenities.Queries.GetDetails;

public class GetHotelAmenityDetailsQuery : IRequest<HotelAmenityVm> {
	public long Id { get; set; }
}
