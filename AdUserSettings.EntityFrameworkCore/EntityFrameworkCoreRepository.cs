using AdUserSettings.EntityFrameworkCore.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdUserSettings.EntityFrameworkCore
{
    public class EntityFrameworkCoreRepository<TEntity> : IEntityFrameworkCoreRepository<TEntity> where TEntity : class, IEntityFramework
    {
        public readonly IEntityFrameworkCoreContextFactory DbContextFactory;

        public EntityFrameworkCoreRepository(IEntityFrameworkCoreContextFactory dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
        }

        public void Create(TEntity entity)
        {
            DbContextFactory.GetDbContext().Set<TEntity>().Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await DbContextFactory.GetDbContext().Set<TEntity>().AddAsync(entity);
        }

        public TEntity Read(int key)
        {
            return DbContextFactory.GetDbContext().Set<TEntity>().Find(key);
        }

        public async Task<TEntity> ReadAsync(int key)
        {
            return await DbContextFactory.GetDbContext().Set<TEntity>().FindAsync(key);
        }

        public IQueryable<TEntity> Read()
        {
            return DbContextFactory.GetDbContext().Set<TEntity>();
        }

        public void Update(TEntity entity, int key)
        {
            if (entity == null) return;
            var exist = DbContextFactory.GetDbContext().Set<TEntity>().Find(key);
            if (exist != null)
            {
                //Context.Entry(exist).State = EntityState.Modified;
                DbContextFactory.GetDbContext().Entry(exist).CurrentValues.SetValues(entity);
            }
        }

        public async Task UpdateAsync(TEntity entity, int key)
        {
            if (entity == null) return;
            var exist = await DbContextFactory.GetDbContext().Set<TEntity>().FindAsync(key);
            if (exist != null)
            {
                //Context.Entry(exist).State = EntityState.Modified;
                DbContextFactory.GetDbContext().Entry(exist).CurrentValues.SetValues(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            DbContextFactory.GetDbContext().Set<TEntity>().Remove(entity);
        }

        #region Aggreates

        public int Count()
        {
            return DbContextFactory.GetDbContext().Set<TEntity>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await DbContextFactory.GetDbContext().Set<TEntity>().CountAsync();
        }

        #endregion
    }
}
