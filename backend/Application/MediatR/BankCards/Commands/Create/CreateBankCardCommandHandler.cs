using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.BankCards.Commands.Create;

public class CreateBankCardCommandHandler(
	IBookingDbContext context,
	IDateConverter dateConverter,
	ICurrentUserService currentUserService
) : IRequestHandler<CreateBankCardCommand, long> {

	public async Task<long> Handle(CreateBankCardCommand request, CancellationToken cancellationToken) {
		var entity = new BankCard {
			Number = request.Number,
			ExpirationDate = dateConverter.ToFirstDayOfMonth(request.ExpirationDate),
			Cvv = request.Cvv,
			OwnerFullName = request.OwnerFullName,
			CustomerId = currentUserService.GetRequiredUserId()
		};

		await context.BankCards.AddAsync(entity, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);

		return entity.Id;
	}
}
