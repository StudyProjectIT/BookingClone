using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Citizenships;

internal static class CitizenshipMappings
{
    internal static CitizenshipDto MapToDto(Citizenship e) => new() { Id = e.Id, Name = e.Name };
}
