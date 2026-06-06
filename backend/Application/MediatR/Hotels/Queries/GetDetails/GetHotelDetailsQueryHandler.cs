using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.Hotels.Queries.GetDetails;

public class GetHotelDetailsQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetHotelDetailsQuery, HotelDetailsVm> {

	public async Task<HotelDetailsVm> Handle(GetHotelDetailsQuery request, CancellationToken cancellationToken) {
		var vm = await context.Hotels
			.AsNoTracking()
			.ProjectTo<HotelDetailsVm>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken)
			?? throw new NotFoundException(nameof(Hotel), request.Id);

		return vm;
	}
}
