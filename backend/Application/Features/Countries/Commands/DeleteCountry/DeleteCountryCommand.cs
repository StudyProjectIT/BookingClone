using Domain.Common;
using MediatR;

namespace Application.Features.Countries.Commands.DeleteCountry;

public record DeleteCountryCommand(long Id) : IRequest<Result<bool>>;
