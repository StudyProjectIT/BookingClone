using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.BankCards.Commands.Delete;

public class DeleteBankCardCommandHandler(
	IBookingDbContext context,
	ICurrentUserService currentUserService
) : IRequestHandler<DeleteBankCardCommand> {

	public async Task Handle(DeleteBankCardCommand request, CancellationToken cancellationToken) {
		var countOfDeleted = await context.BankCards
			.Where(bc => bc.Id == request.Id && bc.CustomerId == currentUserService.GetRequiredUserId())
			.ExecuteDeleteAsync(cancellationToken);

		if (countOfDeleted == 0)
			throw new NotFoundException(nameof(BankCard), request.Id);
	}
}
