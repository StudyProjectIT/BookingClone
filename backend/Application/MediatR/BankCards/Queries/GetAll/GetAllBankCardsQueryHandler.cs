using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Interfaces;
using Application.MediatR.BankCards.Queries.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.BankCards.Queries.GetAll;

public class GetAllBankCardsQueryHandler(
	IBookingDbContext context,
	IMapper mapper,
	ICurrentUserService currentUser
) : IRequestHandler<GetAllBankCardsQuery, IEnumerable<BankCardVm>> {

	public async Task<IEnumerable<BankCardVm>> Handle(GetAllBankCardsQuery request, CancellationToken cancellationToken) {
		var items = await context.BankCards
			.AsNoTracking()
			.Where(bc => bc.CustomerId == currentUser.GetRequiredUserId())
			.ProjectTo<BankCardVm>(mapper.ConfigurationProvider)
			.ToArrayAsync(cancellationToken);

		return items;
	}
}
