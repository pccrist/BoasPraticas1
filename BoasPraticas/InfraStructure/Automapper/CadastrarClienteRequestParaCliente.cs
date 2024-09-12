using AutoMapper;
using BoasPraticas.CQS.Commands.Requests;
using BoasPraticas.Domain.Entities;

namespace BoasPraticas.InfraStructure.Automapper
{
    public class CadastrarClienteRequestParaCliente : Profile
    {
        public CadastrarClienteRequestParaCliente()
        {
            CreateMap<CadastrarClienteRequest, Cliente>()
                .ConstructUsing(c => new Cliente(
                    c.Nome,
                    c.SobreNome,
                    c.CPF,
                    new Email(c.Email)
                    )
                );
        }
    }
}
