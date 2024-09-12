using BoasPraticas.CQS.Responses;
using MediatR;

namespace BoasPraticas.CQS.Queries.Requests
{
    public class BuscarClientePorIdRequest : IRequest<Response>
    {
        public int Id { get; set; } = 0;
    }
}
