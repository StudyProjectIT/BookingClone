using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.UpdateAddress;

public record UpdateAddressCommand(long Id, string Street, string HouseNumber, int? Floor, string? ApartmentNumber, long CityId) : IRequest<Result<AddressDto>>;
