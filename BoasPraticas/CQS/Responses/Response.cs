using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace BoasPraticas.CQS.Responses
{
    [ExcludeFromCodeCoverage]
    public class Response
    {
        readonly List<string> _notifications = new List<string>();

        [JsonPropertyName("notificacoes")]
        public IReadOnlyCollection<string> Notifications => _notifications;

        [JsonPropertyName("temNotificacao")]
        public bool HasNotifications => _notifications.Any();

        [JsonPropertyName("correlationId")]
        public string CorrelationId { get; private set; }

        [JsonPropertyName("data")]
        public object Data { get; private set; }

        public void SetDataValue(object data)
        {
            Data = data;
        }

        public void SetCorrelationId(string correlationId)
        {
            CorrelationId = correlationId;
        }

        public void AddNotification(string message)
        {
            if(!string.IsNullOrEmpty(message))
               _notifications.Add(message);
        }

        public override string ToString() =>
        string.Join("-", _notifications.Select(x => x));



    }
}
