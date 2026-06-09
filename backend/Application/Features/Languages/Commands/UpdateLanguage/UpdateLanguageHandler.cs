using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Languages.Commands.UpdateLanguage;

public class UpdateLanguageHandler(IRepository<Language> repository)
    : IRequestHandler<UpdateLanguageCommand, Result<LanguageDto>>
{
    public async Task<Result<LanguageDto>> Handle(UpdateLanguageCommand request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Language with id {request.Id} not found.");
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Language name is required.");
        entity.Name = request.Name;
        await repository.UpdateAsync(entity, ct);
        return LanguageMappings.MapToDto(entity);
    }
}
