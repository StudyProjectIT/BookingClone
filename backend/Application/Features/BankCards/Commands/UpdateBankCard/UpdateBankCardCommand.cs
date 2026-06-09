using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.BankCards.Commands.UpdateBankCard;

public record UpdateBankCardCommand(long Id, string Number, DateOnly ExpirationDate, string Cvv, string OwnerFullName) : IRequest<Result<BankCardDto>>;
