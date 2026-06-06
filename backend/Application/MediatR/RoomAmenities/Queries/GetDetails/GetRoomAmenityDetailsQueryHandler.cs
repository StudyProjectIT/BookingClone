using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.MediatR.RoomAmenities.Queries.Shared;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.RoomAmenities.Queries.GetDetails;

public class GetRoomAmenityDetailsQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetRoomAmenityDetailsQuery, RoomAmenityVm> {

	public async Task<RoomAmenityVm> Handle(GetRoomAmenityDetailsQuery request, CancellationToken cancellationToken) {
		var vm = await context.RoomAmenities
			.AsNoTracking()
			.ProjectTo<RoomAmenityVm>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(ra => ra.Id == request.Id, cancellationToken)
			?? throw new NotFoundException(nameof(RoomAmenity), request.Id);

		return vm;
	}
}
