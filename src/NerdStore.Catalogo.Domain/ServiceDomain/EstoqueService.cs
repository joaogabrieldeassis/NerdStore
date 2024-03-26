using NerdStore.Catalogo.Domain.Events;
using NerdStore.Catalogo.Domain.Interfaces.Repository;
using NerdStore.Catalogo.Domain.Interfaces.Service;
using NerdStore.Core.Interfaces;

namespace NerdStore.Catalogo.Domain.ServiceDomain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandler _bus;

        public EstoqueService(IProdutoRepository produtoRepository, IMediatrHandler bus)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;            

            produto.DebitarEstoque(quantidade);

            if (produto.QuantidadeEstoque < 10)
            {
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }

            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.IUnitOfWork.Commit();

        }

        public async Task<bool> ReportarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.IUnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }

}
