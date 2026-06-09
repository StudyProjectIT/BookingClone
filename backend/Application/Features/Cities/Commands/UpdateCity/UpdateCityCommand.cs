using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Cities.Commands.UpdateCity;

public record UpdateCityCommand(long Id, string Name, string Image, double Longitude, double Latitude, long CountryId) : IRequest<Result<CityDto>>;
