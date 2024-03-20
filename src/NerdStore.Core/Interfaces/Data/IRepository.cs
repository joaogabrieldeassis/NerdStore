
namespace NerdStore.Core.Interfaces.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        public IUnitOfWork IUnitOfWork { get; }
    }
}
