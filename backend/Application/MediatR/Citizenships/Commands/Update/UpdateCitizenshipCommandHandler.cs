using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.Citizenships.Commands.Update;

public class UpdateCitizenshipCommandHandler(
	IBookingDbContext context
) : IRequestHandler<UpdateCitizenshipCommand> {

	public async Task Handle(UpdateCitizenshipCommand request, CancellationToken cancellationToken) {
		var entity = await context.Citizenships.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(Citizenship), request.Id);

		entity.Name = request.Name;

		await context.SaveChangesAsync(cancellationToken);
	}
}
