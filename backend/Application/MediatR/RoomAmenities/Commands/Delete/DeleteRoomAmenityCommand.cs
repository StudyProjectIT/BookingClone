using MediatR;

namespace Application.MediatR.RoomAmenities.Commands.Delete;

public class DeleteRoomAmenityCommand : IRequest {
	public long Id { get; set; }
}
