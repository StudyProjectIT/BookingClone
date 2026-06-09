using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Cities.Commands.CreateCity;

public record CreateCityCommand(string Name, string Image, double Longitude, double Latitude, long CountryId) : IRequest<Result<CityDto>>;
