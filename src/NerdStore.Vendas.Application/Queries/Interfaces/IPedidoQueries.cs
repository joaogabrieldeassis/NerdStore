using NerdStore.Vendas.Application.Dtos;

namespace NerdStore.Vendas.Application.Queries.Interfaces
{
    public interface IPedidoQueries
    {
        Task<CarrinhoDto> ObterCarrinhoCliente(Guid clienteId);
        Task<IEnumerable<PedidoDto>> ObterPedidosCliente(Guid clienteId);
    }
}
