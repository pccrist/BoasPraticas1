using BoasPraticas.CQS.Queries.Requests;
using BoasPraticas.CQS.Responses;
using BoasPraticas.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BoasPraticas.CQS.Queries.Handlers
{
    public class BuscaClientePorCpfHandler : IRequestHandler<BuscarClientePorCpfRequest, Response>
    {
        readonly IClienteRepositorio _clienteRepositorio;

        public BuscaClientePorCpfHandler(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public async Task<Response> Handle(BuscarClientePorCpfRequest request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var result = await _clienteRepositorio.GetByCpf(request.Cpf);
                response.SetDataValue(result);

                if (result == null)
                    response.AddNotification($"Cliente não localizado pelo CPF: {request.Cpf}");

            }
            catch (Exception ex)
            {
                response.AddNotification(ex.Message);
            }

            return response;
        }
    }
}
