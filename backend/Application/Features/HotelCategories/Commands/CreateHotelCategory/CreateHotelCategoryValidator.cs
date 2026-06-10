using FluentValidation;

namespace Application.Features.HotelCategories.Commands.CreateHotelCategory;

public class CreateHotelCategoryValidator : AbstractValidator<CreateHotelCategoryCommand>
{
    public CreateHotelCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
