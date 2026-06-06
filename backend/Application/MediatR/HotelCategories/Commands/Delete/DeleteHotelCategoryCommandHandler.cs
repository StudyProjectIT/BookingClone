using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.HotelCategories.Commands.Delete;

public class DeleteHotelCategoryCommandHandler(
	IBookingDbContext context
) : IRequestHandler<DeleteHotelCategoryCommand> {

	public async Task Handle(DeleteHotelCategoryCommand request, CancellationToken cancellationToken) {
		var entity = await context.HotelCategories.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(HotelCategory), request.Id);

		context.HotelCategories.Remove(entity);
		await context.SaveChangesAsync(cancellationToken);
	}
}
