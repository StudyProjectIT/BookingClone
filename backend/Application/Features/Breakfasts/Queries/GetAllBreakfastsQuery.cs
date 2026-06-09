using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Breakfasts.Queries;

public record GetAllBreakfastsQuery(int Page, int PageSize) : IRequest<Result<PagedResult<BreakfastDto>>>;
