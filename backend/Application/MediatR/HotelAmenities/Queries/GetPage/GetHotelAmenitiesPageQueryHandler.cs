using Application.Interfaces;
using Application.MediatR.HotelAmenities.Queries.Shared;
using Application.Models.Pagination;
using MediatR;

namespace Application.MediatR.HotelAmenities.Queries.GetPage;

public class GetHotelAmenitiesPageQueryHandler(
	IPaginationService<HotelAmenityVm, GetHotelAmenitiesPageQuery> pagination
) : IRequestHandler<GetHotelAmenitiesPageQuery, PageVm<HotelAmenityVm>> {

	public Task<PageVm<HotelAmenityVm>> Handle(GetHotelAmenitiesPageQuery request, CancellationToken cancellationToken)
		=> pagination.GetPageAsync(request, cancellationToken);
}
