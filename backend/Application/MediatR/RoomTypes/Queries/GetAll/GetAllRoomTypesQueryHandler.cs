using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Interfaces;
using Application.MediatR.RoomTypes.Queries.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.RoomTypes.Queries.GetAll;

public class GetAllRoomTypesQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetAllRoomTypesQuery, IEnumerable<RoomTypeVm>> {

	public async Task<IEnumerable<RoomTypeVm>> Handle(GetAllRoomTypesQuery request, CancellationToken cancellationToken) {
		var items = await context.RoomTypes
			.AsNoTracking()
			.ProjectTo<RoomTypeVm>(mapper.ConfigurationProvider)
			.ToArrayAsync(cancellationToken);

		return items;
	}
}
