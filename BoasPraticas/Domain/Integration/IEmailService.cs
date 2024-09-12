using System.Threading.Tasks;

namespace BoasPraticas.Domain.Integration
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string para, string assunto, string mensagem);
    }
}
