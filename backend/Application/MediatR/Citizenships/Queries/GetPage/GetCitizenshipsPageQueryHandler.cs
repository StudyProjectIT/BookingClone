using Application.Interfaces;
using Application.MediatR.Citizenships.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.Citizenships.Queries.GetPage;

public class GetCitizenshipsPageQueryHandler(
	IPaginationService<CitizenshipVm, GetCitizenshipsPageQuery> pagination
) : IRequestHandler<GetCitizenshipsPageQuery, PageVm<CitizenshipVm>> {

	public Task<PageVm<CitizenshipVm>> Handle(GetCitizenshipsPageQuery request, CancellationToken cancellationToken)
		=> pagination.GetPageAsync(request, cancellationToken);
}
