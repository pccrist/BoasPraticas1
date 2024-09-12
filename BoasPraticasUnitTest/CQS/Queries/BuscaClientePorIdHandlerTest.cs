using BoasPraticas.CQS.Queries.Requests;
using BoasPraticasUnitTest.InfraStructure;
using FluentAssertions;
using MediatR;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using BoasPraticas.Domain.Entities;
using System.Linq;

namespace BoasPraticasUnitTest.CQS.Queries
{
    public class BuscaClientePorIdHandlerTest
    {
        readonly IMediator _mediator;

        public BuscaClientePorIdHandlerTest()
        {
            var serviceProvider = new BootStrapInjection().ServiceProvider;

            _mediator = serviceProvider.GetService<IMediator>();
        }

        [Fact]
        public async Task BuscarTodosClientes()
        {
            var response = await ListaClientes();
            response.Should().NotBeEmpty();
        }

        [Fact]
        public async Task BuscarClientePorIdEncontrado()
        {
            var listaClientes = await ListaClientes();
            var request = new BuscarClientePorIdRequest() { Id = listaClientes.FirstOrDefault().Id };
            var response = await _mediator.Send(request);
            response.HasNotifications.Should().BeFalse();
        }

        [Theory]
        [InlineData(1)]
        public async Task BuscarClientePorIdNãoEncontrado(int id)
        {
            var request = new BuscarClientePorIdRequest() { Id = id };
            var response = await _mediator.Send(request);
            response.HasNotifications.Should().BeTrue();
        }

        async Task<ICollection<Cliente>> ListaClientes()
        {
            var request = new BuscarClientePorIdRequest() { Id = 0 };
            var response = await _mediator.Send(request);
            return (ICollection<Cliente>)response.Data;
        }
    }
}
