using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.BankCards.Commands.CreateBankCard;

public record CreateBankCardCommand(string Number, DateOnly ExpirationDate, string Cvv, string OwnerFullName, long? CustomerId) : IRequest<Result<BankCardDto>>;
