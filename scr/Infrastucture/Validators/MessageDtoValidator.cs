using FluentValidation;
using SimpleMessenger.Contracts.Dto;
using SimpleMessenger.Contracts.Requests;

namespace Infrastucture.Validators;

public class MessageDtoValidator : AbstractValidator<MessageDto>
{
    public MessageDtoValidator()
    {
        RuleFor(message => message.Content).Length(0, 128);
        RuleFor(message => message.SequenceNumber).GreaterThan(0);
    }
}
