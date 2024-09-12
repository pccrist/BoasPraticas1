using BoasPraticas.Domain.Entities;
using System.Threading.Tasks;

namespace BoasPraticas.Domain.Services
{
    public interface IClienteService : IServiceBase
    {
        Task<Cliente> CadastrarCliente(Cliente cliente);
    }
}
