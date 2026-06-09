using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Addresses.Queries.GetAllAddresses;

public class GetAllAddressesHandler(IRepository<Address> repository)
    : IRequestHandler<GetAllAddressesQuery, Result<PagedResult<AddressDto>>>
{
    public async Task<Result<PagedResult<AddressDto>>> Handle(GetAllAddressesQuery request, CancellationToken ct)
    {
        var (items, totalCount) = await repository.GetPagedAsync(request.Page, request.PageSize, ct);
        return new PagedResult<AddressDto>
        {
            Items = items.Select(AddressMappings.MapToDto).ToList().AsReadOnly(),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
