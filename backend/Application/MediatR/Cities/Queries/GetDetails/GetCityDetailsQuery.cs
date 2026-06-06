using Application.MediatR.Cities.Queries.Shared;
using MediatR;

namespace Application.MediatR.Cities.Queries.GetDetails;

public class GetCityDetailsQuery : IRequest<CityVm> {
	public long Id { get; set; }
}
