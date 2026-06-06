using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.MediatR.HotelAmenities.Queries.Shared;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.HotelAmenities.Queries.GetDetails;

public class GetHotelAmenityDetailsQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetHotelAmenityDetailsQuery, HotelAmenityVm> {

	public async Task<HotelAmenityVm> Handle(GetHotelAmenityDetailsQuery request, CancellationToken cancellationToken) {
		var vm = await context.HotelAmenities
			.ProjectTo<HotelAmenityVm>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(ha => ha.Id == request.Id, cancellationToken)
			?? throw new NotFoundException(nameof(HotelAmenity), request.Id);

		return vm;
	}
}
