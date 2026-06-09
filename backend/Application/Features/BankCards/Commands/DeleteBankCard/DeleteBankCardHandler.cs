using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.BankCards.Commands.DeleteBankCard;

public class DeleteBankCardHandler(IRepository<BankCard> repository)
    : IRequestHandler<DeleteBankCardCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteBankCardCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Bank card with id {request.Id} not found.");
        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
