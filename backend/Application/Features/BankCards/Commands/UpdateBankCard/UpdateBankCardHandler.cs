using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.BankCards.Commands.UpdateBankCard;

public class UpdateBankCardHandler(IRepository<BankCard> repository)
    : IRequestHandler<UpdateBankCardCommand, Result<BankCardDto>>
{
    public async Task<Result<BankCardDto>> Handle(UpdateBankCardCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Bank card with id {request.Id} not found.");

        if (string.IsNullOrWhiteSpace(request.Number))
            return Error.Validation("Card number is required.");

        entity.Number = request.Number;
        entity.ExpirationDate = request.ExpirationDate;
        entity.Cvv = request.Cvv;
        entity.OwnerFullName = request.OwnerFullName;
        await repository.UpdateAsync(entity, ct);
        return BankCardMappings.MapToDto(entity);
    }
}
