using Application.DTOs;
using Domain.Common;
using MediatR;

namespace Application.Features.HotelCategories.Queries.GetAllHotelCategories;

public record GetAllHotelCategoriesQuery(int Page, int PageSize) : IRequest<Result<PagedResult<HotelCategoryDto>>>;
