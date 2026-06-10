using Application.DTOs;
using Domain.Common;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.BankCards.Queries.GetBankCardsByCustomerId;

public class GetBankCardsByCustomerIdHandler(IBankCardRepository repository)
    : IRequestHandler<GetBankCardsByCustomerIdQuery, Result<IReadOnlyList<BankCardDto>>>
{
    public async Task<Result<IReadOnlyList<BankCardDto>>> Handle(GetBankCardsByCustomerIdQuery request, CancellationToken ct)
    {
        var cards = await repository.GetByCustomerIdAsync(request.CustomerId, ct);
        return cards.Select(BankCardMappings.MapToDto).ToList().AsReadOnly();
    }
}
