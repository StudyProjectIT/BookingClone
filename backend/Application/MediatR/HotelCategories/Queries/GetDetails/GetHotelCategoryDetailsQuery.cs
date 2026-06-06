using Application.MediatR.HotelCategories.Queries.Shared;
using MediatR;

namespace Application.MediatR.HotelCategories.Queries.GetDetails;

public class GetHotelCategoryDetailsQuery : IRequest<HotelCategoryVm> {
	public long Id { get; set; }
}
