using Application.MediatR.RentalPeriods.Queries.Shared;
using MediatR;

namespace Application.MediatR.RentalPeriods.Queries.GetDetails;

public class GetRentalPeriodDetailsQuery : IRequest<RentalPeriodVm> {
	public long Id { get; set; }
}
