using BoasPraticas.Domain.Constants;
using FluentValidation;

namespace BoasPraticas.CQS.Queries.Requests.Validations
{
    public class BuscarClientePorCpfRequestValidation : AbstractValidator<BuscarClientePorCpfRequest>
    {
        public BuscarClientePorCpfRequestValidation()
        {
            RuleFor(r => r.Cpf)
                .NotEmpty()
                .WithMessage("O parâmetro CPF precisa ser preenchido");

            RuleFor(r => r.Cpf)
                .Length(11)
                .WithMessage(string.Format(MessagesConsts.MSG_LENGTH,"CPF", 11, 11));

        }

    }
}
