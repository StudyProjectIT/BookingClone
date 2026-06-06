using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.Breakfasts.Commands.Update;

public class UpdateBreakfastCommandHandler(
	IBookingDbContext context
) : IRequestHandler<UpdateBreakfastCommand> {

	public async Task Handle(UpdateBreakfastCommand request, CancellationToken cancellationToken) {
		var entity = await context.Breakfasts.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(Breakfast), request.Id);

		entity.Name = request.Name;
		await context.SaveChangesAsync(cancellationToken);
	}
}
