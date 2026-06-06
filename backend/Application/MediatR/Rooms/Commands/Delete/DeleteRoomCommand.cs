using MediatR;

namespace Application.MediatR.Rooms.Commands.Delete;

public class DeleteRoomCommand : IRequest {
	public long Id { get; set; }
}
