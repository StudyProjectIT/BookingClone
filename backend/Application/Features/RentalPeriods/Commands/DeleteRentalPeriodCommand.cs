using Domain.Common;
using MediatR;

namespace Application.Features.RentalPeriods.Commands;

public record DeleteRentalPeriodCommand(long Id) : IRequest<Result<bool>>;
