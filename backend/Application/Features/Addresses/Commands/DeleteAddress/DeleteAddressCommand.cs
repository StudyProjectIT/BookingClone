using Domain.Common;
using MediatR;

namespace Application.Features.Addresses.Commands.DeleteAddress;

public record DeleteAddressCommand(long Id) : IRequest<Result<bool>>;
