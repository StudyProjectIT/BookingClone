using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.RoomTypes.Commands.Create;

public class CreateRoomTypeCommandHandler(
	IBookingDbContext context
) : IRequestHandler<CreateRoomTypeCommand, long> {

	public async Task<long> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken) {
		var entity = new RoomType {
			Name = request.Name
		};

		await context.RoomTypes.AddAsync(entity, cancellationToken);

		await context.SaveChangesAsync(cancellationToken);

		return entity.Id;
	}
}
