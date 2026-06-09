using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.BankCards.Queries.GetBankCardById;

public class GetBankCardByIdHandler(IRepository<BankCard> repository)
    : IRequestHandler<GetBankCardByIdQuery, Result<BankCardDto>>
{
    public async Task<Result<BankCardDto>> Handle(GetBankCardByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Bank card with id {request.Id} not found.");
        return BankCardMappings.MapToDto(entity);
    }
}
