using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.MediatR.Breakfasts.Queries.Shared;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.Breakfasts.Queries.GetDetails;

public class GetBreakfastDetailsQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetBreakfastDetailsQuery, BreakfastVm> {

	public async Task<BreakfastVm> Handle(GetBreakfastDetailsQuery request, CancellationToken cancellationToken) {
		var vm = await context.Breakfasts
			.AsNoTracking()
			.ProjectTo<BreakfastVm>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken)
			?? throw new NotFoundException(nameof(Breakfast), request.Id);

		return vm;
	}
}
