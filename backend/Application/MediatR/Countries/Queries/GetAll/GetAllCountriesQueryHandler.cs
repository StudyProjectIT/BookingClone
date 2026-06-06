using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Interfaces;
using Application.MediatR.Countries.Queries.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.Countries.Queries.GetAll;

public class GetAllCountriesQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryVm>> {

	public async Task<IEnumerable<CountryVm>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken) {
		var items = await context.Countries
			.ProjectTo<CountryVm>(mapper.ConfigurationProvider)
			.ToArrayAsync(cancellationToken);

		return items;
	}
}
