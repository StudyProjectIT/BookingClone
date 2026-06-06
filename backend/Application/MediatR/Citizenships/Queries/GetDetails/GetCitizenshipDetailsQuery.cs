using Application.MediatR.Citizenships.Queries.Shared;
using MediatR;

namespace Application.MediatR.Citizenships.Queries.GetDetails;

public class GetCitizenshipDetailsQuery : IRequest<CitizenshipVm> {
	public long Id { get; set; }
}
