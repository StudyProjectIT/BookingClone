using Application.Interfaces;
using Application.MediatR.RoomTypes.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.RoomTypes.Queries.GetPage;

public class GetRoomTypesPageQueryHandler(
	IPaginationService<RoomTypeVm, GetRoomTypesPageQuery> pagination
) : IRequestHandler<GetRoomTypesPageQuery, PageVm<RoomTypeVm>> {

	public Task<PageVm<RoomTypeVm>> Handle(GetRoomTypesPageQuery request, CancellationToken cancellationToken)
		=> pagination.GetPageAsync(request, cancellationToken);
}
