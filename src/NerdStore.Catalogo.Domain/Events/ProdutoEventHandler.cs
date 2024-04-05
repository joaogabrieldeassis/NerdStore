
using MediatR;
using NerdStore.Catalogo.Domain.Interfaces.Repository;
using NerdStore.Catalogo.Domain.Interfaces.Service;
using NerdStore.Catalogo.Domain.ServiceDomain;
using NerdStore.Core.Events;
using NerdStore.Core.Interfaces;
using NerdStore.Core.Messages.IntegrationEvents;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler :
        INotificationHandler<ProdutoAbaixoEstoqueEvent>,
        INotificationHandler<PedidoIniciadoEvent>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMediatrHandler _mediatorHandler;

        public ProdutoEventHandler(IProdutoRepository produtoRepository,
            IEstoqueService estoqueService, IMediatrHandler mediatrHandler)
        {
            _mediatorHandler = mediatrHandler;
            _estoqueService = estoqueService;
            _produtoRepository = produtoRepository;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent aggregate, CancellationToken cancellationToken)
        {
            await _produtoRepository.ObterPorId(aggregate.AggreagateId);
        }

        public async Task Handle(PedidoIniciadoEvent message, CancellationToken cancellationToken)
        {
            var result = await _estoqueService.DebitarListaProdutosPedido(message.ProdutosPedido);

            if (result)
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(message.PedidoId, message.ClienteId, message.Total, message.ProdutosPedido, message.NomeCartao, message.NumeroCartao, message.ExpiracaoCartao, message.CvvCartao));
            else
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(message.PedidoId, message.ClienteId));
        }
    }
}
