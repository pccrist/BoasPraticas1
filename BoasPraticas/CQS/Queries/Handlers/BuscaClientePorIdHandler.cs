using BoasPraticas.CQS.Queries.Requests;
using BoasPraticas.CQS.Responses;
using BoasPraticas.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BoasPraticas.CQS.Queries.Handlers
{
    public class BuscaClientePorIdHandler : IRequestHandler<BuscarClientePorIdRequest, Response>
    {
        readonly IClienteRepositorio _clienteRepositorio;

        public BuscaClientePorIdHandler(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public async Task<Response> Handle(BuscarClientePorIdRequest request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                object result = null;

                if (request.Id == 0)
                    result = await _clienteRepositorio.GetAll();
                else
                    result = await _clienteRepositorio.GetById(request.Id);

                response.SetDataValue(result);

                if (result == null)
                    response.AddNotification($"Cliente não localizado pelo Id: {request.Id}");
            }
            catch (Exception ex)
            {
                response.AddNotification(ex.Message);
            }

            return response;
        }
    }
}
