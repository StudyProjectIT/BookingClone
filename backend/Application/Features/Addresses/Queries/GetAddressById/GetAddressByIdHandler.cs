using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Addresses.Queries.GetAddressById;

public class GetAddressByIdHandler(IAddressRepository repository)
    : IRequestHandler<GetAddressByIdQuery, Result<AddressDto>>
{
    public async Task<Result<AddressDto>> Handle(GetAddressByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Address with id {request.Id} not found.");

        return AddressMappings.MapToDto(entity);
    }
}
