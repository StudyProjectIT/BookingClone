using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.MediatR.RentalPeriods.Queries.Shared;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.RentalPeriods.Queries.GetDetails;

public class GetRentalPeriodDetailsQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetRentalPeriodDetailsQuery, RentalPeriodVm> {

	public async Task<RentalPeriodVm> Handle(GetRentalPeriodDetailsQuery request, CancellationToken cancellationToken) {
		var vm = await context.RentalPeriods
			.ProjectTo<RentalPeriodVm>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(rp => rp.Id == request.Id, cancellationToken)
			?? throw new NotFoundException(nameof(RentalPeriod), request.Id);

		return vm;
	}
}
