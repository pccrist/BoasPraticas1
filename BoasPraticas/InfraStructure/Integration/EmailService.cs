using BoasPraticas.Domain.Integration;
using System.Threading.Tasks;

namespace BoasPraticas.InfraStructure.Integration
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmail(string para, string assunto, string mensagem)
        {
            return await Task.FromResult(true);
        }
    }
}
