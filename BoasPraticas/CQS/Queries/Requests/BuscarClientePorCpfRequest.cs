using BoasPraticas.CQS.Responses;
using MediatR;

namespace BoasPraticas.CQS.Queries.Requests
{
    public class BuscarClientePorCpfRequest : IRequest<Response>
    {
        public string Cpf { get; set; }
    }
}
