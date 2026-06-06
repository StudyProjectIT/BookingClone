using Application.MediatR.Breakfasts.Queries.Shared;
using MediatR;

namespace Application.MediatR.Breakfasts.Queries.GetDetails;

public class GetBreakfastDetailsQuery : IRequest<BreakfastVm> {
	public long Id { get; set; }
}
