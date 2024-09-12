using BoasPraticas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoasPraticas.Domain.Repositories
{
    public interface IClienteRepositorio
    {
        Task<Cliente> GetById(int id);
        Task<Cliente> GetByCpf(string cpf);
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> CadastrarCliente(Cliente cliente);
    }
}
