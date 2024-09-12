using BoasPraticas.Domain.Entities;
using BoasPraticas.Domain.Integration;
using BoasPraticas.Domain.Repositories;
using BoasPraticas.Domain.Services;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoasPraticas.Services
{
    public class ClienteService : IClienteService
    {
        readonly List<string> _mensagens;

        readonly IClienteRepositorio _clienteRepositorio;
        readonly IApiSerasa _apiSerasa;
        readonly IEmailService _emailService;
        readonly IValidator<Cliente> _clienteValidator;

        public ClienteService(IClienteRepositorio clienteRepositorio, IApiSerasa apiSerasa, IEmailService emailService, IValidator<Cliente> clienteValidator)
        {
            _mensagens = new List<string>();
            _clienteRepositorio = clienteRepositorio;
            _apiSerasa = apiSerasa;
            _emailService = emailService;
            _clienteValidator = clienteValidator;
        }

        public List<string> Mensagens =>
            _mensagens;

        public bool PossuiMensagens =>
            Mensagens.Count > 0;

        public async Task<Cliente> CadastrarCliente(Cliente cliente)
        {
            var validacaoCliente = await _clienteValidator.ValidateAsync(cliente);

            if (!validacaoCliente.IsValid)
            {
                foreach (var failure in validacaoCliente.Errors)
                    _mensagens.Add(failure.ErrorMessage);
                return cliente;
            }

            var possuiDividas = await _apiSerasa.PossuiDividasAtivas(cliente.CPF);

            if (possuiDividas)
                _mensagens.Add("Cliente possui dívidas ativas!");

            if (PossuiMensagens)
                return cliente;

            var clienteExiste = await _clienteRepositorio.GetByCpf(cliente.CPF) != null;

            if (clienteExiste)
            {
                _mensagens.Add("Cliente já cadastrado!");
                return cliente;
            }

            cliente = await _clienteRepositorio.CadastrarCliente(cliente);

            await _emailService.SendEmail(cliente.Email.Address, "Cadastro no Sistema", $"Cliente: {cliente.Nome} cadastrado com sucesso!");

            return cliente;

        }
    }
}
