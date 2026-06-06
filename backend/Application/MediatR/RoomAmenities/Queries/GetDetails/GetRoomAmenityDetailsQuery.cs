using Application.MediatR.RoomAmenities.Queries.Shared;
using MediatR;

namespace Application.MediatR.RoomAmenities.Queries.GetDetails;

public class GetRoomAmenityDetailsQuery : IRequest<RoomAmenityVm> {
	public long Id { get; set; }
}
