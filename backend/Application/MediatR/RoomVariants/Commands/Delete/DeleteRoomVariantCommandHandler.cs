using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.RoomVariants.Commands.Delete;

public class DeleteRoomVariantCommandHandler(
	IBookingDbContext context,
	ICurrentUserService currentUserService
) : IRequestHandler<DeleteRoomVariantCommand> {

	public async Task Handle(DeleteRoomVariantCommand request, CancellationToken cancellationToken) {
		var entity = await context.RoomVariants
			.Include(rv => rv.Room)
				.ThenInclude(r => r.Hotel)
			.FirstOrDefaultAsync(
				rv => rv.Id == request.Id && rv.Room.Hotel.RealtorId == currentUserService.GetRequiredUserId(),
				cancellationToken
			)
			?? throw new NotFoundException(nameof(RoomVariant), request.Id);

		context.RoomVariants.Remove(entity);
		await context.SaveChangesAsync(cancellationToken);
	}
}
