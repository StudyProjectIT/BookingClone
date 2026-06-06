using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Interfaces;
using Application.MediatR.Breakfasts.Queries.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.Breakfasts.Queries.GetAll;

public class GetAllBreakfastsQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetAllBreakfastsQuery, IEnumerable<BreakfastVm>> {

	public async Task<IEnumerable<BreakfastVm>> Handle(GetAllBreakfastsQuery request, CancellationToken cancellationToken) {
		var items = await context.Breakfasts
			.AsNoTracking()
			.ProjectTo<BreakfastVm>(mapper.ConfigurationProvider)
			.ToArrayAsync(cancellationToken);

		return items;
	}
}
