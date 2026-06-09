using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.BankCards.Queries.GetBankCardsByCustomerId;

public class GetBankCardsByCustomerIdHandler(IRepository<BankCard> repository)
    : IRequestHandler<GetBankCardsByCustomerIdQuery, Result<IReadOnlyList<BankCardDto>>>
{
    public async Task<Result<IReadOnlyList<BankCardDto>>> Handle(GetBankCardsByCustomerIdQuery request, CancellationToken ct)
    {
        var all = await repository.GetAllAsync(ct);
        return all.Where(c => c.CustomerId == request.CustomerId)
                  .Select(BankCardMappings.MapToDto)
                  .ToList()
                  .AsReadOnly();
    }
}
