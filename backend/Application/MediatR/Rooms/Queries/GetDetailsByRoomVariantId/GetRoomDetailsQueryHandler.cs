using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.MediatR.Rooms.Queries.Shared;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.Rooms.Queries.GetDetailsByRoomVariantId;

public class GetDetailsByRoomVariantIdQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetDetailsByRoomVariantIdQuery, RoomVm> {

	public async Task<RoomVm> Handle(GetDetailsByRoomVariantIdQuery request, CancellationToken cancellationToken) {
		var vm = await context.Rooms
			.AsNoTracking()
			.ProjectTo<RoomVm>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(r => r.Variants.Any(v => v.Id == request.RoomVariantId), cancellationToken)
			?? throw new NotFoundException(nameof(RoomVariant), request.RoomVariantId);

		return vm;
	}
}
