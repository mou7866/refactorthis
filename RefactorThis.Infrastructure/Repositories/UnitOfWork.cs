using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RefactorThis.Data.Repositories
{
    public class UnitOfWork<TDbContext> : IUnitOfWork
       where TDbContext : DbContext
    {
        protected IDbContextTransaction TransactionContext { get; set; }
        protected DbContext Context { get; init; }
        protected IServiceProvider Services { get; init; }

        private readonly Dictionary<Type, object> Repositories = new();

        public UnitOfWork(TDbContext dbContext, IServiceProvider services)
        {
            Context = dbContext;
            Services = services;
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            if (Repositories.TryGetValue(typeof(TRepository), out var repository))
                return repository as TRepository;

            var newRepository = Services.GetService<TRepository>();
            Repositories.Add(typeof(TRepository), newRepository);
            return newRepository;
        }

        public async Task BeginTransaction()
        {
            TransactionContext = await Context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await TransactionContext.CommitAsync();
        }

        public async Task Commit()
        {
            await Context.SaveChangesAsync();
        }

        public async Task RollBack()
        {
            await Context.Database.RollbackTransactionAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
