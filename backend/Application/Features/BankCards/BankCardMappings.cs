using Application.DTOs;
using Domain.Entities;

namespace Application.Features.BankCards;

internal static class BankCardMappings
{
    internal static BankCardDto MapToDto(BankCard e) => new()
    {
        Id = e.Id,
        Number = e.Number,
        ExpirationDate = e.ExpirationDate,
        OwnerFullName = e.OwnerFullName,
        CustomerId = e.CustomerId
    };
}
