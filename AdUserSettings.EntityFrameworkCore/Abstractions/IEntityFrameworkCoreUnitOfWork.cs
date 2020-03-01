using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdUserSettings.EntityFrameworkCore.Abstractions
{
    public interface IEntityFrameworkCoreUnitOfWork : IDisposable
    {
        //int ExecuteSqlCommand(string sql, params object[] parameters);
        IEntityFrameworkCoreRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntityFramework;
        void BeginTransaction();
        Task BeginTransactionAsync();
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void Commit();
        void Rollback();
    }
}
