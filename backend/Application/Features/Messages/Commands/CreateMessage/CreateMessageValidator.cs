using FluentValidation;

namespace Application.Features.Messages.Commands.CreateMessage;

public class CreateMessageValidator : AbstractValidator<CreateMessageCommand>
{
    public CreateMessageValidator()
    {
        RuleFor(x => x.ChatId).GreaterThan(0);
        RuleFor(x => x.AuthorId).GreaterThan(0);
        RuleFor(x => x.Text).NotEmpty().MaximumLength(4000);
    }
}
