using FluentValidation;

namespace MessagePersistenceService.Application.Features.ChatGroups.Commands.AddChatGroup;

public class AddChatGroupCommandRequestValidator : AbstractValidator<AddChatGroupCommandRequest>
{
    public AddChatGroupCommandRequestValidator()
    {
        RuleFor(i => i.ChatCategoryId).GreaterThan(0);
        RuleFor(i => i.Name).MinimumLength(3);
    }
}
