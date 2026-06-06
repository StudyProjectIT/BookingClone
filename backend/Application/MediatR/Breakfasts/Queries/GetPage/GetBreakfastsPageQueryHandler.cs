using Application.Interfaces;
using Application.MediatR.Breakfasts.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.Breakfasts.Queries.GetPage;

public class GetBreakfastsPageQueryHandler(
	IPaginationService<BreakfastVm, GetBreakfastsPageQuery> pagination
) : IRequestHandler<GetBreakfastsPageQuery, PageVm<BreakfastVm>> {

	public Task<PageVm<BreakfastVm>> Handle(GetBreakfastsPageQuery request, CancellationToken cancellationToken)
		=> pagination.GetPageAsync(request, cancellationToken);
}
