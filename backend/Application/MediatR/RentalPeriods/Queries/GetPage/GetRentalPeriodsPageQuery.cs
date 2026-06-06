using Application.MediatR.RentalPeriods.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.RentalPeriods.Queries.GetPage;

public class GetRentalPeriodsPageQuery : PaginationFilterDto, IRequest<PageVm<RentalPeriodVm>> {
	public string? Name { get; set; }
}
