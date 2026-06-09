using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Languages.Commands.DeleteLanguage;

public class DeleteLanguageHandler(IRepository<Language> repository)
    : IRequestHandler<DeleteLanguageCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteLanguageCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Language with id {request.Id} not found.");
        await repository.DeleteAsync(request.Id, ct);
        return true;
    }
}
