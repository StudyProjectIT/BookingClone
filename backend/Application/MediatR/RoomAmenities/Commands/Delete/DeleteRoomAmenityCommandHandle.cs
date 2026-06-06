using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.RoomAmenities.Commands.Delete;

public class DeleteRoomAmenityCommandHandle(
	IBookingDbContext context
) : IRequestHandler<DeleteRoomAmenityCommand> {

	public async Task Handle(DeleteRoomAmenityCommand request, CancellationToken cancellationToken) {
		var enity = await context.RoomAmenities.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(RoomAmenity), request.Id);

		context.RoomAmenities.Remove(enity);
		await context.SaveChangesAsync(cancellationToken);
	}
}
