using BoasPraticas.Domain.Entities;
using BoasPraticas.Domain.Repositories;
using BoasPraticas.InfraStructure.Data.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace BoasPraticas.InfraStructure.Data
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        readonly IDataContext _dataContext;

        public ClienteRepositorio(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Cliente> GetById(int id)
        {
            var query = $"SELECT * FROM Clientes WHERE Id = {id}";
            var cliente = await _dataContext.DbConnection
                .QueryAsync<Cliente>(query);
            return cliente.FirstOrDefault();
        }

        public async Task<Cliente> GetByCpf(string cpf)
        {
            var query = $"SELECT * FROM Clientes WHERE CPF = '{cpf}'";
            var cliente = await _dataContext.DbConnection
                .QueryAsync<Cliente>(query);
            return cliente.FirstOrDefault();
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            var query = $"SELECT * FROM Clientes";
            var cliente = await _dataContext.DbConnection
                .QueryAsync<Cliente>(query);
            return cliente.ToList();
        }

        public async Task<Cliente> CadastrarCliente(Cliente cliente)
        {
            using var cmd = _dataContext.DbConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO Clientes(Id, Nome, SobreNome, CPF, Email) VALUES (@Id, @Nome, @SobreNome, @CPF, @Email)";
            cmd.Parameters.Add(new SQLiteParameter("@Id", cliente.Id));
            cmd.Parameters.Add(new SQLiteParameter("@Nome", cliente.Nome));
            cmd.Parameters.Add(new SQLiteParameter("@SobreNome", cliente.SobreNome));
            cmd.Parameters.Add(new SQLiteParameter("@CPF", cliente.CPF));
            cmd.Parameters.Add(new SQLiteParameter("@Email", cliente.Email.Address));
            await cmd.ExecuteNonQueryAsync();
            return cliente;

        }
    }
}
