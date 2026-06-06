using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.Cities.Commands.Delete;

public class DeleteCityCommandHandler(
	IBookingDbContext context,
	IImageService imageService
) : IRequestHandler<DeleteCityCommand> {

	public async Task Handle(DeleteCityCommand request, CancellationToken cancellationToken) {
		var entity = await context.Cities.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(City), request.Id);

		context.Cities.Remove(entity);
		await context.SaveChangesAsync(cancellationToken);

		imageService.DeleteImageIfExists(entity.Image);
	}
}
