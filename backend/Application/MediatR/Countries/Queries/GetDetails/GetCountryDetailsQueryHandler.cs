using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.MediatR.Countries.Queries.Shared;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.Countries.Queries.GetDetails;

public class GetCountryDetailsQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetCountryDetailsQuery, CountryVm> {

	public async Task<CountryVm> Handle(GetCountryDetailsQuery request, CancellationToken cancellationToken) {
		var vm = await context.Countries
			.ProjectTo<CountryVm>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
			?? throw new NotFoundException(nameof(Country), request.Id);

		return vm;
	}
}
