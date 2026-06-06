using Application.MediatR.Breakfasts.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.Breakfasts.Queries.GetPage;

public class GetBreakfastsPageQuery : PaginationFilterDto, IRequest<PageVm<BreakfastVm>> {
	public string? Name { get; set; }
}
