using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Queries.GetAllAddresses;

public record GetAllAddressesQuery(int Page, int PageSize) : IRequest<Result<PagedResult<AddressDto>>>;
