using BoasPraticas.Domain.Entities;
using BoasPraticas.Domain.Services;
using BoasPraticasUnitTest.InfraStructure;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace BoasPraticasUnitTest.Services
{
    public class ClienteServiceTest
    {
        readonly IClienteService _clienteService;

        public ClienteServiceTest()
        {
            var serviceProvider = new BootStrapInjection().ServiceProvider;

            _clienteService = serviceProvider.GetService<IClienteService>();
        }

        [Theory]
        [InlineData("Clark", "Kent", "12345678920", "clark.kent@domain.com")]

        public async Task TestaCadastrarClienteComSucesso(string nome, string sobrenome, string cpf, string email)
        {
            var cliente = new Cliente(nome, sobrenome, cpf, new Email(email));
            _ = await _clienteService.CadastrarCliente(cliente);
            _clienteService.PossuiMensagens.Should().BeFalse();
        }
    }
}
