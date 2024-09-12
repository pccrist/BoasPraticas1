using BoasPraticas.CQS.Commands.Requests;
using BoasPraticasUnitTest.InfraStructure;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace BoasPraticasUnitTest.CQS.Commands
{
    public class CadastrarClienteRequestTest
    {
        readonly IValidator<CadastrarClienteRequest> _clienteValidator;

        public CadastrarClienteRequestTest()
        {
            var serviceProvider = new BootStrapInjection().ServiceProvider;

            _clienteValidator = serviceProvider.GetService<IValidator<CadastrarClienteRequest>>();
        }

        [Theory]
        [InlineData("Clark", "Kent", "12345678901", "clark.Kent@domain.com")]
        [InlineData("Bruce", "Wayne", "12345678902", "bruce.wayne@domain.com")]
        [InlineData("Bruce", "Banner", "12345678903", "bruce.baner@domain.com")]

        public async Task TestaClienteValido(string nome, string sobrenome, string cpf, string email)
        {
            var cliente = new CadastrarClienteRequest() {Nome = nome, SobreNome = sobrenome, CPF = cpf, Email = email};
            var validacaoCliente = await _clienteValidator.ValidateAsync(cliente);
            validacaoCliente.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("", "Kent", "12345678901", "clark.Kent@domain.com")]
        [InlineData("B", "Wayne", "12345678902", "bruce.wayne@domain.com")]
        [InlineData("B", "Banner", "12345678903", "bruce.baner@domain.com")]

        public async Task TestaClienteNomeInvalido(string nome, string sobrenome, string cpf, string email)
        {
            var cliente = new CadastrarClienteRequest() { Nome = nome, SobreNome = sobrenome, CPF = cpf, Email = email };
            var validacaoCliente = await _clienteValidator.ValidateAsync(cliente);
            validacaoCliente.IsValid.Should().BeFalse();
        }


    }
}
