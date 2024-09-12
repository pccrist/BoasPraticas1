using BoasPraticas.Domain.Constants;
using FluentValidation;

namespace BoasPraticas.Domain.Entities.Validations
{
    public class EmailValidation : AbstractValidator<Email>
    {
        public EmailValidation()
        {

            RuleFor(r => r.Address)
                .NotEmpty()
                .WithMessage(string.Format(MessagesConsts.MSG_NOTEMPTY, "Email"));

            RuleFor(r => r.Address)
                .EmailAddress()
                .WithMessage(MessagesConsts.MSG_EMAIL_INVALIDO);

        }
    }
}
