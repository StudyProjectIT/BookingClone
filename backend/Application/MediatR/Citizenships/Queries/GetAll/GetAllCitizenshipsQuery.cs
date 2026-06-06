using Application.MediatR.Citizenships.Queries.Shared;
using MediatR;

namespace Application.MediatR.Citizenships.Queries.GetAll;

public class GetAllCitizenshipsQuery : IRequest<IEnumerable<CitizenshipVm>> { }
