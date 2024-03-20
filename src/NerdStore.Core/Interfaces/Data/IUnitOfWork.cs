
namespace NerdStore.Core.Interfaces.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Comit();
    }
}
