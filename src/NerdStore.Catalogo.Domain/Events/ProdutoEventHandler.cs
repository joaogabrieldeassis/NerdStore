
using MediatR;
using NerdStore.Catalogo.Domain.Interfaces.Repository;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoEventHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent aggregate, CancellationToken cancellationToken)
        {
            await _produtoRepository.ObterPorId(aggregate.AggreagateId);
        }
    }
}
