using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Breakfasts.Queries;

public record GetBreakfastByIdQuery(long Id) : IRequest<Result<BreakfastDto>>;
