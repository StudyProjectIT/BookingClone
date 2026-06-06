using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.Breakfasts.Commands.Delete;

public class DeleteBreakfastCommandHandler(
	IBookingDbContext context
) : IRequestHandler<DeleteBreakfastCommand> {

	public async Task Handle(DeleteBreakfastCommand request, CancellationToken cancellationToken) {
		var entity = await context.Breakfasts.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(Breakfast), request.Id);

		context.Breakfasts.Remove(entity);
		await context.SaveChangesAsync(cancellationToken);
	}
}
