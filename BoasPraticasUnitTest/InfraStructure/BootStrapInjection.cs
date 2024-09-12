using BoasPraticas.Controllers.v1;
using BoasPraticas.CQS.Commands.Requests;
using BoasPraticas.CQS.Commands.Requests.Validations;
using BoasPraticas.CQS.Queries.Requests;
using BoasPraticas.CQS.Queries.Requests.Validations;
using BoasPraticas.Domain.Entities;
using BoasPraticas.Domain.Entities.Validations;
using BoasPraticas.Domain.Integration;
using BoasPraticas.Domain.Repositories;
using BoasPraticas.Domain.Services;
using BoasPraticas.InfraStructure.Automapper;
using BoasPraticas.InfraStructure.Integration;
using BoasPraticas.Mock.Repositories;
using BoasPraticas.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BoasPraticasUnitTest.InfraStructure
{
    public class BootStrapInjection
    {
        readonly ServiceCollection _services;

        public BootStrapInjection()
        {
            _services = new ServiceCollection();

            BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider { get; private set; }

        void BuildServiceProvider()
        {
            AddMediatoR();
            AddAutoMapper();
            AddCadastrarCliente();
            AddValidations();
            AddControllers();

            ServiceProvider = _services.BuildServiceProvider();
        }

        void AddMediatoR()
        {
            var assembly = AppDomain.CurrentDomain.Load("BoasPraticas");
            _services.AddMediatR(assembly);
        }

        void AddAutoMapper()
        {
            _services.AddAutoMapper(typeof(CadastrarClienteRequestParaCliente));
        }
        void AddCadastrarCliente()
        {
            _services.AddScoped<IClienteRepositorio, ClienteRepositorioMock>();
            _services.AddScoped<IApiSerasa, ApiSerasa>();
            _services.AddScoped<IEmailService, EmailService>();
            _services.AddScoped<IClienteService, ClienteService>();
        }

        void AddValidations()
        {
            // Domain
            _services.AddTransient<IValidator<Cliente>, ClienteValidation>();
            _services.AddTransient<IValidator<Email>, EmailValidation>();

            // Requests
            _services.AddTransient<IValidator<CadastrarClienteRequest>, CadastrarClienteRequestValidation>();
            _services.AddTransient<IValidator<BuscarClientePorCpfRequest>, BuscarClientePorCpfRequestValidation>();
        }

        void AddControllers()
        {
            _services.AddScoped<ClientesController>();
        }
    }
}
