using Application.MediatR.Rooms.Queries.Shared;
using MediatR;

namespace Application.MediatR.Rooms.Queries.GetDetailsByRoomVariantId;

public class GetDetailsByRoomVariantIdQuery : IRequest<RoomVm> {
	public long RoomVariantId { get; set; }
}
