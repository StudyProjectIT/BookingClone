using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Interfaces;
using Application.MediatR.Genders.Queries.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.Genders.Queries.GetAll;

public class GetAllGendersQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetAllGendersQuery, IEnumerable<GenderVm>> {

	public async Task<IEnumerable<GenderVm>> Handle(GetAllGendersQuery request, CancellationToken cancellationToken) {
		var items = await context.Genders
			.AsNoTracking()
			.ProjectTo<GenderVm>(mapper.ConfigurationProvider)
			.ToArrayAsync(cancellationToken);

		return items;
	}
}
