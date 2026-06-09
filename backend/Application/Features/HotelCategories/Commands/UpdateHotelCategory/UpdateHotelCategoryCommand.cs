using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelCategories.Commands.UpdateHotelCategory;

public record UpdateHotelCategoryCommand(long Id, string Name) : IRequest<Result<HotelCategoryDto>>;
