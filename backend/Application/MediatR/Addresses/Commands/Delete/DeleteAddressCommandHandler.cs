using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.Addresses.Commands.Delete;

public class DeleteAddressCommandHandler(
	IBookingDbContext context
) : IRequestHandler<DeleteAddressCommand> {

	public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken) {
		var entity = await context.Addresses
			.FindAsync([request.Id], cancellationToken)
			?? throw new NotFoundException(nameof(Address), request.Id);

		context.Addresses.Remove(entity);
		await context.SaveChangesAsync(cancellationToken);
	}
}