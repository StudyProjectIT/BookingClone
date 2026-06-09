using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Addresses.Commands.CreateAddress;

public class CreateAddressHandler(IRepository<Address> repository)
    : IRequestHandler<CreateAddressCommand, Result<AddressDto>>
{
    public async Task<Result<AddressDto>> Handle(CreateAddressCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Street))
            return Error.Validation("Street is required.");

        var entity = new Address
        {
            Street = request.Street,
            HouseNumber = request.HouseNumber,
            Floor = request.Floor,
            ApartmentNumber = request.ApartmentNumber,
            CityId = request.CityId
        };
        var created = await repository.AddAsync(entity, ct);
        return AddressMappings.MapToDto(created);
    }
}
