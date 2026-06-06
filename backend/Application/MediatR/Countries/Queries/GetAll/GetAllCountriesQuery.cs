using Application.MediatR.Countries.Queries.Shared;
using MediatR;

namespace Application.MediatR.Countries.Queries.GetAll;

public class GetAllCountriesQuery : IRequest<IEnumerable<CountryVm>> { }
