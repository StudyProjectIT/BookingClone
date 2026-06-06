using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.HotelAmenities.Commands.Update;

public class UpdateHotelAmenityCommandHandler(
	IBookingDbContext context,
	IImageService imageService
) : IRequestHandler<UpdateHotelAmenityCommand> {

	public async Task Handle(UpdateHotelAmenityCommand request, CancellationToken cancellationToken) {
		var entity = await context.HotelAmenities.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(HotelAmenity), request.Id);

		string oldImage = entity.Image;

		entity.Name = request.Name;
		entity.Image = await imageService.SaveImageAsync(request.Image);

		try {
			await context.SaveChangesAsync(cancellationToken);

			imageService.DeleteImageIfExists(oldImage);
		}
		catch {
			imageService.DeleteImageIfExists(entity.Image);
			throw;
		}
	}
}
