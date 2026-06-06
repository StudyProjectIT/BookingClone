using Application.MediatR.Citizenships.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.Citizenships.Queries.GetPage;

public class GetCitizenshipsPageQuery : PaginationFilterDto, IRequest<PageVm<CitizenshipVm>> {
	public string? Name { get; set; }
}
