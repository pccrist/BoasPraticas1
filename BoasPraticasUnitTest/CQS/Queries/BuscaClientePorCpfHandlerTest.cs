using BoasPraticas.CQS.Queries.Requests;
using BoasPraticasUnitTest.InfraStructure;
using FluentAssertions;
using MediatR;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace BoasPraticasUnitTest.CQS.Queries
{
    public class BuscaClientePorCpfHandlerTest
    {
        readonly IMediator _mediator;
        readonly IValidator<BuscarClientePorCpfRequest> _clienteRequestCPFValidator;

        public BuscaClientePorCpfHandlerTest()
        {
            var serviceProvider = new BootStrapInjection().ServiceProvider;

            _mediator = serviceProvider.GetService<IMediator>();
            _clienteRequestCPFValidator = serviceProvider.GetService<IValidator<BuscarClientePorCpfRequest>>();
        }

        [Theory]
        [InlineData("12345678901")]

        public async Task TestaClienteRequestValido(string cpf)
        {
            var clienteRequest = new BuscarClientePorCpfRequest() { Cpf = cpf };
            var validacaoCliente = await _clienteRequestCPFValidator.ValidateAsync(clienteRequest);
            validacaoCliente.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("123")]

        public async Task TestaClienteRequestInvalido(string cpf)
        {
            var clienteRequest = new BuscarClientePorCpfRequest() { Cpf = cpf };
            var validacaoCliente = await _clienteRequestCPFValidator.ValidateAsync(clienteRequest);
            validacaoCliente.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("12345678901")]

        public async Task BuscarClientePorCPFEncontrado(string cpf)
        {
            var request = new BuscarClientePorCpfRequest() { Cpf = cpf };
            var response = await _mediator.Send(request);
            response.HasNotifications.Should().BeFalse();

        }

        [Theory]
        [InlineData("123")]

        public async Task BuscarClientePorCPFNaoEncontrado(string cpf)
        {
            var request = new BuscarClientePorCpfRequest() { Cpf = cpf };
            var response = await _mediator.Send(request);
            response.HasNotifications.Should().BeTrue();

        }

    }
}
