using BoasPraticas.InfraStructure.Automapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace BoasPraticas.InfraStructure.IoC
{
    [ExcludeFromCodeCoverage]
    public static class BootStrapAutoMapper
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(CadastrarClienteRequestParaCliente));

            return services;
        }
    }
}
