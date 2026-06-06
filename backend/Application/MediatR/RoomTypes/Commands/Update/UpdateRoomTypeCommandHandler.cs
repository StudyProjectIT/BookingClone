using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.RoomTypes.Commands.Update;

public class UpdateRoomTypeCommandHandler(
	IBookingDbContext context
) : IRequestHandler<UpdateRoomTypeCommand> {

	public async Task Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken) {
		var entity = await context.RoomTypes.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(RoomType), request.Id);

		entity.Name = request.Name;

		await context.SaveChangesAsync(cancellationToken);
	}
}
