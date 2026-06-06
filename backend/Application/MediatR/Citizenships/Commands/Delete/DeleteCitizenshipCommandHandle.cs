using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.Citizenships.Commands.Delete;

public class DeleteCitizenshipCommandHandle(
	IBookingDbContext context
) : IRequestHandler<DeleteCitizenshipCommand> {

	public async Task Handle(DeleteCitizenshipCommand request, CancellationToken cancellationToken) {
		var enity = await context.Citizenships.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(Citizenship), request.Id);

		context.Citizenships.Remove(enity);
		await context.SaveChangesAsync(cancellationToken);
	}
}
