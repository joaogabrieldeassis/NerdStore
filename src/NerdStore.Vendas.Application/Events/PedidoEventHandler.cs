using MediatR;
using NerdStore.Core.Interfaces;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoEventHandler :
        INotificationHandler<PedidoRascunhoIniciadoEvent>,
        INotificationHandler<PedidoItemAdicionadoEvent>,
        INotificationHandler<PedidoAtualizadoEvent>
    {

        private readonly IMediatrHandler _mediatorHandler;

        public PedidoEventHandler(IMediatrHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public Task Handle(PedidoRascunhoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(PedidoItemAdicionadoEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(PedidoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
