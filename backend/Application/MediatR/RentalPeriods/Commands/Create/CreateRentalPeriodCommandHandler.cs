using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.RentalPeriods.Commands.Create;

public class CreateRentalPeriodCommandHandler(
	IBookingDbContext context
) : IRequestHandler<CreateRentalPeriodCommand, long> {

	public async Task<long> Handle(CreateRentalPeriodCommand request, CancellationToken cancellationToken) {
		var entity = new RentalPeriod {
			Name = request.Name,
		};

		await context.RentalPeriods.AddAsync(entity, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);

		return entity.Id;
	}
}
