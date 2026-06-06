using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.GuestInfos.Commands.Create;

public class CreateGuestInfoCommandHandler(
	IBookingDbContext context
) : IRequestHandler<CreateGuestInfoCommand, long> {
	public async Task<long> Handle(CreateGuestInfoCommand request, CancellationToken cancellationToken) {
		var entity = new GuestInfo {
			RoomVariantId = request.RoomVariantId,
			AdultCount = request.AdultCount,
			ChildCount = request.ChildCount
		};

		await context.GuestInfos.AddAsync(entity, cancellationToken);

		await context.SaveChangesAsync(cancellationToken);

		return entity.RoomVariantId;
	}
}
