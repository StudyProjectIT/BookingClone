using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Countries.Commands.UpdateCountry;

public record UpdateCountryCommand(long Id, string Name, string Image) : IRequest<Result<CountryDto>>;
