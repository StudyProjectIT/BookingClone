using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Genders;

internal static class GenderMappings
{
    internal static GenderDto MapToDto(Gender e) => new() { Id = e.Id, Name = e.Name };
}
