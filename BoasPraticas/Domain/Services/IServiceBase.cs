using System.Collections.Generic;

namespace BoasPraticas.Domain.Services
{
    public interface IServiceBase
    {
        bool PossuiMensagens { get; }
        List<string> Mensagens { get; }
    }
}
