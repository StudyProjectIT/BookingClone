using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Queries.GetAddressById;

public record GetAddressByIdQuery(long Id) : IRequest<Result<AddressDto>>;
