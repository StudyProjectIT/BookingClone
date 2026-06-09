using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RentalPeriods.Queries;

public record GetRentalPeriodByIdQuery(long Id) : IRequest<Result<RentalPeriodDto>>;
