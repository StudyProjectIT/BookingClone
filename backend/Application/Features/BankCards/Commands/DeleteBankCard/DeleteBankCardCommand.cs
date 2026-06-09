using Domain.Common;
using MediatR;

namespace Application.Features.BankCards.Commands.DeleteBankCard;

public record DeleteBankCardCommand(long Id) : IRequest<Result<bool>>;
