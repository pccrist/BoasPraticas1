using BoasPraticas.CQS.Commands.Requests;
using BoasPraticas.CQS.Commands.Requests.Validations;
using BoasPraticas.CQS.Queries.Requests;
using BoasPraticas.CQS.Queries.Requests.Validations;
using BoasPraticas.Domain.Entities;
using BoasPraticas.Domain.Entities.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace BoasPraticas.InfraStructure.IoC
{
    [ExcludeFromCodeCoverage]
    public static class BootStrapValidations
    {
        public static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));

            // Domain
            services.AddTransient<IValidator<Cliente>, ClienteValidation>();

            //Requests
            services.AddTransient<IValidator<CadastrarClienteRequest>, CadastrarClienteRequestValidation>();
            services.AddTransient<IValidator<BuscarClientePorCpfRequest>, BuscarClientePorCpfRequestValidation>();

            return services;
        }
    }
}
