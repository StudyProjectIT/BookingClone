using Application.Interfaces;
using Application.MediatR.Countries.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.Countries.Queries.GetPage;

public class GetCountriesPageQueryHandler(
	IPaginationService<CountryVm, GetCountriesPageQuery> pagination
) : IRequestHandler<GetCountriesPageQuery, PageVm<CountryVm>> {

	public Task<PageVm<CountryVm>> Handle(GetCountriesPageQuery request, CancellationToken cancellationToken)
		=> pagination.GetPageAsync(request, cancellationToken);
}
