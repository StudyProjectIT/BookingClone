using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Interfaces;
using Application.MediatR.RentalPeriods.Queries.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.RentalPeriods.Queries.GetAll;

public class GetAllRentalPeriodsQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetAllRentalPeriodsQuery, IEnumerable<RentalPeriodVm>> {

	public async Task<IEnumerable<RentalPeriodVm>> Handle(GetAllRentalPeriodsQuery request, CancellationToken cancellationToken) {
		var items = await context.RentalPeriods
			.ProjectTo<RentalPeriodVm>(mapper.ConfigurationProvider)
			.ToArrayAsync(cancellationToken);

		return items;
	}
}
