using System.Threading.Tasks;

namespace BoasPraticas.Domain.Integration
{
    public interface IApiSerasa
    {
        Task<bool> PossuiDividasAtivas(string cpf);
    }
}
