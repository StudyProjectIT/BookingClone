using FluentValidation;

namespace Application.Features.Messages.Commands.UpdateMessage;

public class UpdateMessageValidator : AbstractValidator<UpdateMessageCommand>
{
    public UpdateMessageValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Text).NotEmpty().MaximumLength(4000);
    }
}
