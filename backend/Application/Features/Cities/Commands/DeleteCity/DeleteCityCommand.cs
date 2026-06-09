using Domain.Common;
using MediatR;

namespace Application.Features.Cities.Commands.DeleteCity;

public record DeleteCityCommand(long Id) : IRequest<Result<bool>>;
