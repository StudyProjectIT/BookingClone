using Application.DTOs;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Languages.Queries.GetLanguageById;

public class GetLanguageByIdHandler(IRepository<Language> repository)
    : IRequestHandler<GetLanguageByIdQuery, Result<LanguageDto>>
{
    public async Task<Result<LanguageDto>> Handle(GetLanguageByIdQuery request, CancellationToken ct)
    {
        var entity = await repository.GetByIdAsync(request.Id, ct);
        if (entity is null)
            return Error.NotFound($"Language with id {request.Id} not found.");
        return LanguageMappings.MapToDto(entity);
    }
}
