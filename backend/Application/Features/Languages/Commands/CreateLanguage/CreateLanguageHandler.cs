using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Languages.Commands.CreateLanguage;

public class CreateLanguageHandler(IRepository<Language> repository)
    : IRequestHandler<CreateLanguageCommand, Result<LanguageDto>>
{
    public async Task<Result<LanguageDto>> Handle(CreateLanguageCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Error.Validation("Language name is required.");
        var entity = new Language { Name = request.Name };
        var created = await repository.AddAsync(entity, ct);
        return LanguageMappings.MapToDto(created);
    }
}
