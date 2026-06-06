using Application.Interfaces;
using Application.MediatR.Hotels.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.Hotels.Queries.GetPage;

public class GetHotelsPageQueryHandler(
	IPaginationService<HotelVm, GetHotelsPageQuery> pagination
) : IRequestHandler<GetHotelsPageQuery, PageVm<HotelVm>> {

	public Task<PageVm<HotelVm>> Handle(GetHotelsPageQuery request, CancellationToken cancellationToken) =>
		pagination.GetPageAsync(request, cancellationToken);
}