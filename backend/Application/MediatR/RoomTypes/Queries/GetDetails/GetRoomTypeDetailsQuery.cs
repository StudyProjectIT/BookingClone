using Application.MediatR.RoomTypes.Queries.Shared;
using MediatR;

namespace Application.MediatR.RoomTypes.Queries.GetDetails;

public class GetRoomTypeDetailsQuery : IRequest<RoomTypeVm> {
	public long Id { get; set; }
}
