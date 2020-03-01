using AdUserSettings.EntityFrameworkCore.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace AdUserSettings.EntityFrameworkCore
{
    public class EntityFrameworkCoreUnitOfWork : IEntityFrameworkCoreUnitOfWork
    {
        #region Constructor

        private readonly IEntityFrameworkCoreContextFactory _factory;

        public EntityFrameworkCoreUnitOfWork(IEntityFrameworkCoreContextFactory factory)
        {
            _factory = factory;
        }

        #endregion

        public IEntityFrameworkCoreRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntityFramework
        {
            return new EntityFrameworkCoreRepository<TEntity>(_factory);
        }

        public void BeginTransaction()
        {
            _factory.GetDbContext().Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            await _factory.GetDbContext().Database.BeginTransactionAsync();
        }

        public int SaveChanges()
        {
            try
            {
                return _factory.GetDbContext().SaveChanges();
            }
            catch (DbUpdateConcurrencyException exception)
            {
                Debug.WriteLine($"{exception.Message}");
            }
            catch (DbUpdateException exception)
            {
                Debug.WriteLine($"{exception.Message}");
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"{exception.Message}");
            }

            return 0;
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _factory.GetDbContext().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException exception)
            {
                Debug.WriteLine($"{exception.Message}");
            }
            catch (DbUpdateException exception)
            {
                Debug.WriteLine($"{exception.Message}");
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"{exception.Message}");
            }

            return 0;
        }

        public void Commit()
        {
            _factory.GetDbContext().Database.CommitTransaction();
        }

        public void Rollback()
        {
            _factory.GetDbContext().Database.RollbackTransaction();
        }

        #region Dispose

        private bool _disposed;

        protected void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _factory.GetDbContext().Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
