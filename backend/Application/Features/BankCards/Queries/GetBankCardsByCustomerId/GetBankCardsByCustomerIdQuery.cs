using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.BankCards.Queries.GetBankCardsByCustomerId;

public record GetBankCardsByCustomerIdQuery(long CustomerId) : IRequest<Result<IReadOnlyList<BankCardDto>>>;
