using FluentValidation;

namespace Application.Features.BankCards.Commands.CreateBankCard;

public class CreateBankCardValidator : AbstractValidator<CreateBankCardCommand>
{
    public CreateBankCardValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .Length(13, 19)
            .WithMessage("Card number must be between 13 and 19 characters.");
        RuleFor(x => x.Cvv)
            .NotEmpty()
            .Length(3, 4)
            .WithMessage("CVV must be 3 or 4 digits.");
        RuleFor(x => x.OwnerFullName).NotEmpty().MaximumLength(255);
        RuleFor(x => x.ExpirationDate)
            .Must(d => d >= DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Card expiration date must be in the future.");
    }
}
