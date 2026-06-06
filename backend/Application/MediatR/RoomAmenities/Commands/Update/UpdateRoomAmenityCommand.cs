using MediatR;

namespace Application.MediatR.RoomAmenities.Commands.Update;

public class UpdateRoomAmenityCommand : IRequest {
	public long Id { get; set; }

	public string Name { get; set; } = null!;
}
