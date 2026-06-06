using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.GuestInfos.Commands.Delete;

public class DeleteGuestInfoCommandHandler(
	IBookingDbContext context,
	ICurrentUserService currentUserService
) : IRequestHandler<DeleteGuestInfoCommand> {

	public async Task Handle(DeleteGuestInfoCommand request, CancellationToken cancellationToken) {
		var entity = await context.GuestInfos
			.Include(gi => gi.RoomVariant)
				.ThenInclude(rv => rv.Room)
					.ThenInclude(r => r.Hotel)
			.FirstOrDefaultAsync(
				gi => gi.RoomVariantId == request.RoomVariantId
					&& gi.RoomVariant.Room.Hotel.RealtorId == currentUserService.GetRequiredUserId(),
				cancellationToken
			)
			?? throw new NotFoundException(nameof(GuestInfo), request.RoomVariantId);

		context.GuestInfos.Remove(entity);
		await context.SaveChangesAsync(cancellationToken);
	}
}
