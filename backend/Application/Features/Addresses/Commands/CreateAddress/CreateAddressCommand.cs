using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.CreateAddress;

public record CreateAddressCommand(string Street, string HouseNumber, int? Floor, string? ApartmentNumber, long CityId) : IRequest<Result<AddressDto>>;
