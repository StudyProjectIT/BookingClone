using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Addresses.Commands.UpdateAddress;

public class UpdateAddressHandler(IRepository<Address> repository)
    : IRequestHandler<UpdateAddressCommand, Result<AddressDto>>
{
    public async Task<Result<AddressDto>> Handle(UpdateAddressCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Address with id {request.Id} not found.");

        if (string.IsNullOrWhiteSpace(request.Street))
            return Error.Validation("Street is required.");

        entity.Street = request.Street;
        entity.HouseNumber = request.HouseNumber;
        entity.Floor = request.Floor;
        entity.ApartmentNumber = request.ApartmentNumber;
        entity.CityId = request.CityId;
        await repository.UpdateAsync(entity, ct);
        return AddressMappings.MapToDto(entity);
    }
}
