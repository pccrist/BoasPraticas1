using BoasPraticas.Domain.Entities;
using BoasPraticasUnitTest.InfraStructure;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace BoasPraticasUnitTest.Domain
{
    public class EmailTest
    {
        readonly IValidator<Email> _emailValidator;

        public EmailTest()
        {
            var serviceProvider = new BootStrapInjection().ServiceProvider;

            _emailValidator = serviceProvider.GetService<IValidator<Email>>();
        }

        [Theory]
        [InlineData("clark.kent@domain.com")]
        [InlineData("bruce.wayne@domain.com")]
        [InlineData("bruce.banner@doman.com")]
        public async Task TestaEmailValido(string emailAddress)
        {
            var email = new Email(emailAddress);
            var validacaoEmail = await _emailValidator.ValidateAsync(email);
            validacaoEmail.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("bruce.wayne.domain")]
        [InlineData( "bruce.banner")]
        public async Task TestaEmailInvalido(string emailAddress)
        {
            var email = new Email(emailAddress);
            var validacaoEmail = await _emailValidator.ValidateAsync(email);
            validacaoEmail.IsValid.Should().BeFalse();
        }
    }
}
