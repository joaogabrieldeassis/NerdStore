namespace NerdStore.Catalogo.Domain.Interfaces.Service
{
    public interface IEstoqueService : IDisposable
    {
        Task<bool> DebitarEstoque(Guid produtoId, int quantidade);
        Task<bool> ReportarEstoque(Guid produtoId, int quantidade);
    }
}
