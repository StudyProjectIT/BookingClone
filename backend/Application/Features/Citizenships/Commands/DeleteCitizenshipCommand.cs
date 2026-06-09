using Domain.Common;
using MediatR;

namespace Application.Features.Citizenships.Commands;

public record DeleteCitizenshipCommand(long Id) : IRequest<Result<bool>>;
