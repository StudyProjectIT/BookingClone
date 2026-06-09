using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RentalPeriods.Commands;

public record UpdateRentalPeriodCommand(long Id, string Name) : IRequest<Result<RentalPeriodDto>>;
