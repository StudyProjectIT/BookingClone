using Application.MediatR.RentalPeriods.Queries.Shared;
using MediatR;

namespace Application.MediatR.RentalPeriods.Queries.GetAll;

public class GetAllRentalPeriodsQuery : IRequest<IEnumerable<RentalPeriodVm>> { }
