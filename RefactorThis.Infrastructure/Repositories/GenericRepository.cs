using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RefactorThis.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DbContext DbContext { get; init; }
        private DbSet<TEntity> DbSet { get; init; }
        public GenericRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }
        public async virtual Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            if (filter is not null)
                query = query.Where(filter);
            includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(includeProperty => query = query.Include(includeProperty));
            var queryToExecute = (orderBy is null)
                ? query.ToList()
                : orderBy(query).ToList();
            return await Task.Run<IEnumerable<TEntity>>(() => queryToExecute);
        }
        public async virtual Task<TEntity> GetById(object id)
        {
            return await DbSet.FindAsync(id);
        }
        public async virtual Task<TEntity> Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }
        public async virtual Task Delete(object id)
        {
            var entity = await DbSet.FindAsync(id);
            await Delete(entity);
        }
        public async virtual Task Delete(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
                DbSet.Attach(entity);
            await Task.Run(() => DbSet.Remove(entity));
        }
        public async virtual Task Update(TEntity entity)
        {
            await Task.Run(() =>
            {
                DbSet.Attach(entity);
                DbContext.Entry(entity).State = EntityState.Modified;
            });
        }
    }
}
