
using NerdStore.Core.Messages;

namespace NerdStore.Core.Interfaces
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task EnviarComando<T>(T evento) where T : Command;
    }
}
