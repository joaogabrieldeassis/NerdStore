using AutoMapper;
using NerdStore.Catalogo.Application.Dtos;
using NerdStore.Catalogo.Application.interfaces;
using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Catalogo.Domain.Interfaces.Repository;
using NerdStore.Catalogo.Domain.Interfaces.Service;
using NerdStore.Core.Exeptions;

namespace NerdStore.Catalogo.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IEstoqueService _estoqueService;

        public ProdutoAppService(IProdutoRepository produtoRepository, IMapper mapper, IEstoqueService estoqueService)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _estoqueService = estoqueService;
        }

        public async Task<IEnumerable<CategoriaDto>> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaDto>>(await _produtoRepository.ObterCategorias());
        }

        public async Task<IEnumerable<ProdutoDto>> ObterPorCategoria(int codigo)
        {
            return _mapper.Map<IEnumerable<ProdutoDto>>(await _produtoRepository.ObterPorCategoria(codigo));
        }

        public async Task<ProdutoDto> ObterPorId(Guid id)
        {
            return _mapper.Map<ProdutoDto>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<ProdutoDto>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoDto>>(await _produtoRepository.ObterTodos());
        }

        public async Task AdicionarProduto(ProdutoDto produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _produtoRepository.Adicionar(produto);

            await _produtoRepository.IUnitOfWork.Commit();
        }

        public async Task AtualizarProduto(ProdutoDto produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _produtoRepository.Atualizar(produto);

            await _produtoRepository.IUnitOfWork.Commit();
        }

        public async Task<ProdutoDto> DebitarEstoque(Guid id, int quantidade)
        {
            if (!await _estoqueService.DebitarEstoque(id, quantidade))
                throw new DomainException("Falha ao debitar o estoque");

            return _mapper.Map<ProdutoDto>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<ProdutoDto> ReporEstoque(Guid id, int quantidade)
        {
            if (!await _estoqueService.ReportarEstoque(id, quantidade))
                throw new DomainException("Falha ao repor o estoque");

            return _mapper.Map<ProdutoDto>(await _produtoRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
            _estoqueService?.Dispose();
        }
    }
}
