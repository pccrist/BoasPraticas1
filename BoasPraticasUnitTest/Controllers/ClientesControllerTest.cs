using BoasPraticas.Controllers.v1;
using BoasPraticas.CQS.Commands.Requests;
using BoasPraticas.Domain.Entities;
using BoasPraticasUnitTest.InfraStructure;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace BoasPraticasUnitTest.Controllers
{
    public class ClientesControllerTest
    {
        readonly ClientesController _clientesController;

        public ClientesControllerTest()
        {
            var serviceProvider = new BootStrapInjection().ServiceProvider;
            _clientesController = serviceProvider.GetService<ClientesController>();

        }

        [Theory]
        [InlineData("Clark", "kent", "12345678920", "clark.kent@domain.com")]
        public async Task<Cliente> TestaCadastrarClienteComSucesso(string nome, string sobrenome, string cpf, string email)
        {
            var cliente = new CadastrarClienteRequest() { Nome = nome, SobreNome = sobrenome, CPF = cpf, Email = email };
            var response = await _clientesController.CadastrarCliente(cliente) as OkObjectResult;
            response.StatusCode.Should().Be(200);
            return (Cliente)response.Value;
        }
    }
}
