using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.Languages.Commands.Update;

public class UpdateLanguageCommandHandler(
	IBookingDbContext context
) : IRequestHandler<UpdateLanguageCommand> {

	public async Task Handle(UpdateLanguageCommand request, CancellationToken cancellationToken) {
		var entity = await context.Languages.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(Language), request.Id);

		entity.Name = request.Name;
		await context.SaveChangesAsync(cancellationToken);
	}
}
