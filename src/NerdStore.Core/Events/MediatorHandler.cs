using MediatR;
using NerdStore.Core.Interfaces;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Events
{
    public class MediatorHandler : IMediatrHandler
    {
        private IMediator _mediador;

        public MediatorHandler(IMediator mediador)
        {
            _mediador = mediador;
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediador.Publish(evento);
        }


        public async Task EnviarComando<T>(T evento) where T : Command
        {
           await _mediador.Send(evento);
        }
    }
}
