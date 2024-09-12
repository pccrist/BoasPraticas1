using BoasPraticas.Domain.Entities;
using BoasPraticas.Domain.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoasPraticas.Mock.Repositories
{
    public class ClienteRepositorioMock : IClienteRepositorio
    {
        readonly Mock<IClienteRepositorio> _service;
        readonly static ICollection<Cliente> _listaDeCliente = new List<Cliente>()
        {
            new Cliente("Tony", "Stark", "12345678901", new Email("tony.stark@domain.com.br")),
            new Cliente("Bruce", "Banner", "12345678902", new Email("bruce.banner@domain.com.br")),
            new Cliente("Tony", "Wayne", "12345678903", new Email("bruce.wayne@domain.com.br"))

        };

        public ClienteRepositorioMock()
        {
            _service = new Mock<IClienteRepositorio>();
        }

        public async Task<Cliente> GetById(int id)
        {
            _service.Setup(x => x.GetById(It.Is<int>(p => p ==id)))
                .ReturnsAsync(_listaDeCliente.FirstOrDefault(x => x.Id == id));

            return await _service.Object.GetById(id);
        }

        public async Task<Cliente> GetByCpf(string cpf)
        {
            _service.Setup(x => x.GetByCpf(It.Is<string>(p => p == cpf)))
                .ReturnsAsync(_listaDeCliente.FirstOrDefault(x => x.CPF == cpf));

            return await _service.Object.GetByCpf(cpf);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            _service.Setup(x => x.GetAll())
                .ReturnsAsync(_listaDeCliente);

            return await _service.Object.GetAll();
        }

        public async Task<Cliente> CadastrarCliente(Cliente cliente)
        {
            _service.Setup(x => x.CadastrarCliente(It.IsAny<Cliente>()))
                .ReturnsAsync(cliente);

            var result = await _service.Object.CadastrarCliente(cliente);

            _listaDeCliente.Add(result);

            return result;
        }


    }
}
