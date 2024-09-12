using System.Data.Common;

namespace BoasPraticas.InfraStructure.Data.Interfaces
{
    public interface IDataContext
    {
        DbConnection DbConnection { get; }
    }
}
