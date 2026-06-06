using Application.MediatR.HotelCategories.Queries.Shared;
using MediatR;

namespace Application.MediatR.HotelCategories.Queries.GetAll;

public class GetAllHotelCategoriesQuery : IRequest<IEnumerable<HotelCategoryVm>> { }
