using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.BankCards.Queries.GetBankCardById;

public record GetBankCardByIdQuery(long Id) : IRequest<Result<BankCardDto>>;
