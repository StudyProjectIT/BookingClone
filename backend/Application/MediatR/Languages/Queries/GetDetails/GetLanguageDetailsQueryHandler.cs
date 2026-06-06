using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.MediatR.Languages.Queries.Shared;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.Languages.Queries.GetDetails;

public class GetLanguageDetailsQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetLanguageDetailsQuery, LanguageVm> {

	public async Task<LanguageVm> Handle(GetLanguageDetailsQuery request, CancellationToken cancellationToken) {
		var vm = await context.Languages
			.AsNoTracking()
			.ProjectTo<LanguageVm>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken)
			?? throw new NotFoundException(nameof(Language), request.Id);

		return vm;
	}
}
