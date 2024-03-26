
namespace NerdStore.Core.Interfaces.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
