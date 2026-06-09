using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.BankCards.Commands.CreateBankCard;

public class CreateBankCardHandler(IRepository<BankCard> repository)
    : IRequestHandler<CreateBankCardCommand, Result<BankCardDto>>
{
    public async Task<Result<BankCardDto>> Handle(CreateBankCardCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Number))
            return Error.Validation("Card number is required.");

        var entity = new BankCard
        {
            Number = request.Number,
            ExpirationDate = request.ExpirationDate,
            Cvv = request.Cvv,
            OwnerFullName = request.OwnerFullName,
            CustomerId = request.CustomerId
        };
        var created = await repository.AddAsync(entity, ct);
        return BankCardMappings.MapToDto(created);
    }
}
