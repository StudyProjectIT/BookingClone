using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RentalPeriods.Commands;

public record CreateRentalPeriodCommand(string Name) : IRequest<Result<RentalPeriodDto>>;
