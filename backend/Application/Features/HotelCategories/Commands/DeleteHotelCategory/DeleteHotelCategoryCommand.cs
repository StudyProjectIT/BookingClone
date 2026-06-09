using Domain.Common;
using MediatR;

namespace Application.Features.HotelCategories.Commands.DeleteHotelCategory;

public record DeleteHotelCategoryCommand(long Id) : IRequest<Result<bool>>;
