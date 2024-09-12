using BoasPraticas.InfraStructure.Data;
using BoasPraticas.InfraStructure.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;


namespace BoasPraticas.InfraStructure.IoC
{
    [ExcludeFromCodeCoverage]
    public static class BootStrapDataContext
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services)
        {
            _ = services ?? throw new ArgumentNullException(nameof(services));
            services.AddSingleton<IDataContext, DataContext>();
            return services;

        }
    }
}
