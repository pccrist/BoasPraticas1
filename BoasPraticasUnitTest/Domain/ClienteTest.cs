using BoasPraticas.Domain.Entities;
using BoasPraticasUnitTest.InfraStructure;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace BoasPraticasUnitTest.Domain
{
    public class ClienteTest
    {
        readonly IValidator<Cliente> _clienteValidator;

        public ClienteTest()
        {
            var serviceProvider = new BootStrapInjection().ServiceProvider;
            _clienteValidator = serviceProvider.GetService<IValidator<Cliente>>();
        }

        [Theory]
        [InlineData("Clark", "Kent", "12345678901", "clark.kent@domain.com")]
        [InlineData("Bruce", "Wayne", "12345678902", "bruce.wayne@domain.com")]
        [InlineData("Bruce", "Banner", "12345678903", "bruce.banner@domain.com")]
        public async Task TestaClienteValido(string nome, string sobrenome, string cpf, string email)
        {
            var cliente = new Cliente(nome, sobrenome, cpf, new Email(email));
            var validacaoCliente = await _clienteValidator.ValidateAsync(cliente);
            validacaoCliente.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("", "Kent", "12345678901", "clark.kent@domain.com")]
        [InlineData("B", "Wayne", "12345678902", "bruce.wayne@domain.com")]
        [InlineData("Br", "Banner", "12345678903", "bruce.banner@domain.com")]
        public async Task TestaClienteNomeInvalido(string nome, string sobrenome, string cpf, string email)
        {
            var cliente = new Cliente(nome, sobrenome, cpf, new Email(email));
            var validacaoCliente = await _clienteValidator.ValidateAsync(cliente);
            validacaoCliente.IsValid.Should().BeFalse();
        }

    }
}
