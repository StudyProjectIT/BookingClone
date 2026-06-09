using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Languages;

internal static class LanguageMappings
{
    internal static LanguageDto MapToDto(Language e) => new() { Id = e.Id, Name = e.Name };
}
