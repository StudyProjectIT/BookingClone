using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.MediatR.Rooms.Queries.Shared;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.Rooms.Queries.GetDetails;

public class GetRoomDetailsQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetRoomDetailsQuery, RoomVm> {

	public async Task<RoomVm> Handle(GetRoomDetailsQuery request, CancellationToken cancellationToken) {
		var vm = await context.Rooms
			.AsNoTracking()
			.ProjectTo<RoomVm>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken)
			?? throw new NotFoundException(nameof(Room), request.Id);

		return vm;
	}
}
