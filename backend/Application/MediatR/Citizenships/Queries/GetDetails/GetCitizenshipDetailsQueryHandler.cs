using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.MediatR.Citizenships.Queries.Shared;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.Citizenships.Queries.GetDetails;

public class GetCitizenshipDetailsQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetCitizenshipDetailsQuery, CitizenshipVm> {

	public async Task<CitizenshipVm> Handle(GetCitizenshipDetailsQuery request, CancellationToken cancellationToken) {
		var vm = await context.Citizenships
			.AsNoTracking()
			.ProjectTo<CitizenshipVm>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
			?? throw new NotFoundException(nameof(Citizenship), request.Id);

		return vm;
	}
}
