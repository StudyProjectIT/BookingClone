using Application.Interfaces;
using Application.MediatR.Cities.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.Cities.Queries.GetPage;

public class GetCitiesPageQueryHandler(
	IPaginationService<CityVm, GetCitiesPageQuery> pagination
) : IRequestHandler<GetCitiesPageQuery, PageVm<CityVm>> {

	public Task<PageVm<CityVm>> Handle(GetCitiesPageQuery request, CancellationToken cancellationToken) =>
		 pagination.GetPageAsync(request, cancellationToken);
}
