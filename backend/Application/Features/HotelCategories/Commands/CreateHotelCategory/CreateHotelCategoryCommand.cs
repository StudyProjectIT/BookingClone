using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelCategories.Commands.CreateHotelCategory;

public record CreateHotelCategoryCommand(string Name) : IRequest<Result<HotelCategoryDto>>;
