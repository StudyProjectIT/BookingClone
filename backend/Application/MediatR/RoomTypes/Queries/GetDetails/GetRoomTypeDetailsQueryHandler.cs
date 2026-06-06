using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.MediatR.RoomTypes.Queries.Shared;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.RoomTypes.Queries.GetDetails;

public class GetRoomTypeDetailsQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetRoomTypeDetailsQuery, RoomTypeVm> {

	public async Task<RoomTypeVm> Handle(GetRoomTypeDetailsQuery request, CancellationToken cancellationToken) {
		var vm = await context.RoomTypes
			.AsNoTracking()
			.ProjectTo<RoomTypeVm>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(rt => rt.Id == request.Id, cancellationToken)
			?? throw new NotFoundException(nameof(RoomType), request.Id);

		return vm;
	}
}
