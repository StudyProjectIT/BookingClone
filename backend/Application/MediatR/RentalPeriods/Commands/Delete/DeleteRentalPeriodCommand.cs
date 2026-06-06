using MediatR;

namespace Application.MediatR.RentalPeriods.Commands.Delete;

public class DeleteRentalPeriodCommand : IRequest {
	public long Id { get; set; }
}
