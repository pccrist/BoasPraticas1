using BoasPraticas.InfraStructure.Data;
using BoasPraticas.InfraStructure.Integration;
using BoasPraticas.Mock.Repositories;
using BoasPraticas.Services;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BoasPraticas.Domain.Repositories;
using BoasPraticas.Domain.Integration;
using BoasPraticas.Domain.Services;
using System;


namespace BoasPraticas.InfraStructure.IoC
{
    [ExcludeFromCodeCoverage]
    public static class BootStrapCadastrarCliente
    {
        public static IServiceCollection AddCadastrarClienteService(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));
            _ = configuration ?? throw new ArgumentNullException(nameof(configuration));

            bool.TryParse(configuration.GetSection("ApiConfiguration")["MockDeDados"], out bool mockDados);

            if (mockDados)
                services.AddSingleton<IClienteRepositorio, ClienteRepositorioMock>();
            else
                services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            services.AddSingleton<IApiSerasa, ApiSerasa>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddScoped<IClienteService, ClienteService>();

            return services;
        }

    }
}
