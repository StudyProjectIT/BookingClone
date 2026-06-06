using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.Rooms.Commands.Delete;

public class DeleteRoomCommandHandler(
	IBookingDbContext context,
	ICurrentUserService currentUserService
) : IRequestHandler<DeleteRoomCommand> {

	public async Task Handle(DeleteRoomCommand request, CancellationToken cancellationToken) {
		var entity = await context.Rooms
			.Include(r => r.Hotel)
			.FirstOrDefaultAsync(
				r => r.Id == request.Id && r.Hotel.RealtorId == currentUserService.GetRequiredUserId(),
				cancellationToken
			)
			?? throw new NotFoundException(nameof(Room), request.Id);

		context.Rooms.Remove(entity);
		await context.SaveChangesAsync(cancellationToken);
	}
}
