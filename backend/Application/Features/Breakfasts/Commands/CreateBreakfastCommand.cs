using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Breakfasts.Commands;

public record CreateBreakfastCommand(string Name) : IRequest<Result<BreakfastDto>>;
