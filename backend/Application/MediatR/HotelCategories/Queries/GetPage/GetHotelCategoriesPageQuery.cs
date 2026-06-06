using Application.MediatR.HotelCategories.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.HotelCategories.Queries.GetPage;

public class GetHotelCategoriesPageQuery : PaginationFilterDto, IRequest<PageVm<HotelCategoryVm>> {
	public string? Name { get; set; }
}
