using BoasPraticas.InfraStructure.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace BoasPraticas.InfraStructure.Data
{
    public class DataContext : IDataContext
    {
        readonly string _database;
        DbConnection _dbConnection;

        public DataContext(IConfiguration configuration) 
        {
            _database = configuration["ApiConfiguration:SLiteDatabase"];

            CreateDatabase();
            OpenDatabase();
            CreateTableCliente();

        }

        public DbConnection DbConnection => _dbConnection;

        void CreateDatabase()
        {
            if (!File.Exists(_database))
            {
                SQLiteConnection.CreateFile(_database);
            }

        }

        void OpenDatabase()
        {
            _dbConnection = new SQLiteConnection($@"Data Source={_database};");
            _dbConnection.Open();
        }

        void CreateTableCliente()
        {
            using var cmd = DbConnection.CreateCommand();
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS Clientes(Id int, Nome Varchar(50), SobreNome Varchar(50), CPF Varchar(11), Email Varchar(80))";
            cmd.ExecuteNonQuery();
        
        }
    }
}
