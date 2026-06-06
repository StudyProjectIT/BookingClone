using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.RoomTypes.Commands.Delete;

public class DeleteRoomTypeCommandHandle(
	IBookingDbContext context
) : IRequestHandler<DeleteRoomTypeCommand> {

	public async Task Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken) {
		var enity = await context.RoomTypes.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(RoomType), request.Id);

		context.RoomTypes.Remove(enity);
		await context.SaveChangesAsync(cancellationToken);
	}
}
