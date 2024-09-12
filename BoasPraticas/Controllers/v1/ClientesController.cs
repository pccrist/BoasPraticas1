using AutoMapper;
using BoasPraticas.CQS.Commands.Requests;
using BoasPraticas.CQS.Queries.Requests;
using BoasPraticas.Domain.Entities;
using BoasPraticas.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace BoasPraticas.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ClientesController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly IMediator _mediator;
        readonly IClienteService _clienteService;

        public ClientesController(IMapper mapper, IMediator mediator, IClienteService clienteService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarCliente([FromBody] CadastrarClienteRequest cadastrarClienteRequest)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(cadastrarClienteRequest);
                var result = await _clienteService.CadastrarCliente(cliente);

                if (_clienteService.PossuiMensagens)
                    return BadRequest(_clienteService.Mensagens);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarClientePorId([FromQuery] BuscarClientePorIdRequest requestId)
        {
            try
            {
                var response = await _mediator.Send(requestId);

                if (response.HasNotifications)
                    return BadRequest(response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("porCPF")]
        public async Task<IActionResult> BuscarClientePorCPF([FromQuery] BuscarClientePorCpfRequest requestCPF)
        {
            try 
            { 
                var response = await _mediator.Send(requestCPF);
                if (response.HasNotifications)
                    return BadRequest(response);

                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
