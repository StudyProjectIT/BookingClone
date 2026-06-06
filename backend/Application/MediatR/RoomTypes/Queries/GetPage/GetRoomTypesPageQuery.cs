using Application.MediatR.RoomTypes.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.RoomTypes.Queries.GetPage;

public class GetRoomTypesPageQuery : PaginationFilterDto, IRequest<PageVm<RoomTypeVm>> {
	public string? Name { get; set; }
}
