using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.RentalPeriods.Queries;

public record GetAllRentalPeriodsQuery(int Page, int PageSize) : IRequest<Result<PagedResult<RentalPeriodDto>>>;
