using Application.Interfaces;
using Application.MediatR.RoomAmenities.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.RoomAmenities.Queries.GetPage;

public class GetRoomAmenitiesPageQueryHandler(
	IPaginationService<RoomAmenityVm, GetRoomAmenitiesPageQuery> pagination
) : IRequestHandler<GetRoomAmenitiesPageQuery, PageVm<RoomAmenityVm>> {

	public Task<PageVm<RoomAmenityVm>> Handle(GetRoomAmenitiesPageQuery request, CancellationToken cancellationToken)
		=> pagination.GetPageAsync(request, cancellationToken);
}
