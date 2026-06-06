using Application.MediatR.Countries.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.Countries.Queries.GetPage;

public class GetCountriesPageQuery : PaginationFilterDto, IRequest<PageVm<CountryVm>> {
	public string? Name { get; set; }
}
