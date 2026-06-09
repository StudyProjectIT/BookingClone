using Domain.Common;
using MediatR;

namespace Application.Features.Genders.Commands;

public record DeleteGenderCommand(long Id) : IRequest<Result<bool>>;
