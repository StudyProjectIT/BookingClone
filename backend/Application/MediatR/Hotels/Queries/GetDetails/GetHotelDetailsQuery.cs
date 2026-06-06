using MediatR;

namespace Application.MediatR.Hotels.Queries.GetDetails;

public class GetHotelDetailsQuery : IRequest<HotelDetailsVm> {
	public long Id { get; set; }
}
