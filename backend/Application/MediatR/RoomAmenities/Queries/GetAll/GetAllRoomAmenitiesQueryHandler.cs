using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Interfaces;
using Application.MediatR.RoomAmenities.Queries.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MediatR.RoomAmenities.Queries.GetAll;

public class GetAllRoomAmenitiesQueryHandler(
	IBookingDbContext context,
	IMapper mapper
) : IRequestHandler<GetAllRoomAmenitiesQuery, IEnumerable<RoomAmenityVm>> {

	public async Task<IEnumerable<RoomAmenityVm>> Handle(GetAllRoomAmenitiesQuery request, CancellationToken cancellationToken) {
		var items = await context.RoomAmenities
			.AsNoTracking()
			.ProjectTo<RoomAmenityVm>(mapper.ConfigurationProvider)
			.ToArrayAsync(cancellationToken);

		return items;
	}
}
