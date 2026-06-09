using Domain.Common;
using MediatR;

namespace Application.Features.Breakfasts.Commands;

public record DeleteBreakfastCommand(long Id) : IRequest<Result<bool>>;
