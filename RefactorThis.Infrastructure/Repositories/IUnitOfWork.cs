using System;
using System.Threading.Tasks;

namespace RefactorThis.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction();

        Task CommitTransaction();

        Repository GetRepository<Repository>() where Repository : class;

        Task Commit();

        Task RollBack();
    }
}
