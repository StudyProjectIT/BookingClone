using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Countries.Commands.CreateCountry;

public record CreateCountryCommand(string Name, string Image) : IRequest<Result<CountryDto>>;
