using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.RoomAmenities.Commands.Update;

public class UpdateRoomAmenityCommandHandler(
	IBookingDbContext context
) : IRequestHandler<UpdateRoomAmenityCommand> {

	public async Task Handle(UpdateRoomAmenityCommand request, CancellationToken cancellationToken) {
		var entity = await context.RoomAmenities.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(RoomAmenity), request.Id);

		entity.Name = request.Name;

		await context.SaveChangesAsync(cancellationToken);
	}
}
