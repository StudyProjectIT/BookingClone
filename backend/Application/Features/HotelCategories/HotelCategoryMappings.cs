using Application.DTOs;
using Domain.Entities;

namespace Application.Features.HotelCategories;

internal static class HotelCategoryMappings
{
    internal static HotelCategoryDto MapToDto(HotelCategory e) => new() { Id = e.Id, Name = e.Name };
}
