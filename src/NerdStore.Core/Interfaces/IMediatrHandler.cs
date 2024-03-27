
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.ComunMessages.Notifications;

namespace NerdStore.Core.Interfaces
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task EnviarComando<T>(T evento) where T : Command;
        Task PublicarNotificacao<T>(T notificao) where T : DomainNotification;
    }
}
