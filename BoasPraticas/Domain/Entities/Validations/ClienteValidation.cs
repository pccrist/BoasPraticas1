using BoasPraticas.Domain.Constants;
using FluentValidation;

namespace BoasPraticas.Domain.Entities.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(r => r.Nome)
                .NotEmpty()
                .WithMessage(string.Format(MessagesConsts.MSG_NOTEMPTY, "Nome"));

            RuleFor(r => r.Nome)
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage(string.Format(MessagesConsts.MSG_LENGTH, "Nome", 3, 50));

            RuleFor(r => r.SobreNome)
                .NotEmpty()
                .WithMessage(string.Format(MessagesConsts.MSG_NOTEMPTY, "Sobre Nome"));

            RuleFor(r => r.SobreNome)
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage(string.Format(MessagesConsts.MSG_LENGTH, "Nome", 3, 50));

            RuleFor(r => r.CPF)
                .NotEmpty()
                .WithMessage(string.Format(MessagesConsts.MSG_NOTEMPTY, "CPF"));

            RuleFor(r => r.CPF)
                .Length(11)
                .WithMessage(string.Format(MessagesConsts.MSG_LENGTH, "CPF", 11, 11));

            RuleFor(r => r.Email)
                .SetValidator(new EmailValidation());


        }
    }
}
