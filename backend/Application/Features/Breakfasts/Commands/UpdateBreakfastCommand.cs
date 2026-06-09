using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Breakfasts.Commands;

public record UpdateBreakfastCommand(long Id, string Name) : IRequest<Result<BreakfastDto>>;
