using Application.DTOs;
using Domain.Entities;

namespace Application.Features.Breakfasts;

internal static class BreakfastMappings
{
    internal static BreakfastDto MapToDto(Breakfast e) => new() { Id = e.Id, Name = e.Name };
}
