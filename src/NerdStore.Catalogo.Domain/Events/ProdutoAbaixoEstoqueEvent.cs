

using NerdStore.Core.Events;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoAbaixoEstoqueEvent : DomainEvent
    {
        public ProdutoAbaixoEstoqueEvent(Guid agregateId, int quantidadeRestante)
            : base(agregateId)
        {
            QuantidadeRestante = quantidadeRestante;
        }
        public int QuantidadeRestante { get; private set; }
    }
}
