using FluentValidation;

namespace Application.Features.HotelCategories.Commands.UpdateHotelCategory;

public class UpdateHotelCategoryValidator : AbstractValidator<UpdateHotelCategoryCommand>
{
    public UpdateHotelCategoryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
