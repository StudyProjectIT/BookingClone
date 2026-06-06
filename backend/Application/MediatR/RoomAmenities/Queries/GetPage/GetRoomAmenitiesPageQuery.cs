using Application.MediatR.RoomAmenities.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.RoomAmenities.Queries.GetPage;

public class GetRoomAmenitiesPageQuery : PaginationFilterDto, IRequest<PageVm<RoomAmenityVm>> {
	public string? Name { get; set; }
}
