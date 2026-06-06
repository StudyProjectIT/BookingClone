using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.Languages.Commands.Create;

public class CreateLanguageCommandHandler(
	IBookingDbContext context
) : IRequestHandler<CreateLanguageCommand, long> {

	public async Task<long> Handle(CreateLanguageCommand request, CancellationToken cancellationToken) {
		var entity = new Language {
			Name = request.Name
		};

		await context.Languages.AddAsync(entity, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);

		return entity.Id;
	}
}
