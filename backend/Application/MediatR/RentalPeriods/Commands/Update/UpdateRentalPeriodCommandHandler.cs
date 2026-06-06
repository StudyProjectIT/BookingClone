using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.RentalPeriods.Commands.Update;

public class UpdateRentalPeriodCommandHandler(
	IBookingDbContext context
) : IRequestHandler<UpdateRentalPeriodCommand> {

	public async Task Handle(UpdateRentalPeriodCommand request, CancellationToken cancellationToken) {
		var entity = await context.RentalPeriods.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(RentalPeriod), request.Id);

		entity.Name = request.Name;
		await context.SaveChangesAsync(cancellationToken);
	}
}
