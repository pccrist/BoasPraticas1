using BoasPraticas.Domain.Integration;
using System.Threading.Tasks;

namespace BoasPraticas.InfraStructure.Integration
{
    public class ApiSerasa : IApiSerasa
    {
        public async Task<bool> PossuiDividasAtivas(string cpf)
        {
            return await Task.FromResult(false);
        }
    }
}
