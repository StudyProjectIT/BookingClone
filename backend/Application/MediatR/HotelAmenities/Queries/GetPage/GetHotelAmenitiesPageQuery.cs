using Application.MediatR.HotelAmenities.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.HotelAmenities.Queries.GetPage;

public class GetHotelAmenitiesPageQuery : PaginationFilterDto, IRequest<PageVm<HotelAmenityVm>> {
	public string? Name { get; set; }
}
