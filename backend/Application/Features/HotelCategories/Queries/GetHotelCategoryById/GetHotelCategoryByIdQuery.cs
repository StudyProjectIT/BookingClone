using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelCategories.Queries.GetHotelCategoryById;

public record GetHotelCategoryByIdQuery(long Id) : IRequest<Result<HotelCategoryDto>>;
