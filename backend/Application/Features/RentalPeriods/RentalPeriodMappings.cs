using Application.DTOs;
using Domain.Entities;

namespace Application.Features.RentalPeriods;

internal static class RentalPeriodMappings
{
    internal static RentalPeriodDto MapToDto(RentalPeriod e) => new() { Id = e.Id, Name = e.Name };
}
