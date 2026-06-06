using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.RentalPeriods.Commands.Delete;

public class DeleteRentalPeriodCommandHandler(
	IBookingDbContext context
) : IRequestHandler<DeleteRentalPeriodCommand> {

	public async Task Handle(DeleteRentalPeriodCommand request, CancellationToken cancellationToken) {
		var entity = await context.RentalPeriods.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(RentalPeriod), request.Id);

		context.RentalPeriods.Remove(entity);
		await context.SaveChangesAsync(cancellationToken);
	}
}
