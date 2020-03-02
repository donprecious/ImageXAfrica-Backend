using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ImageAfricaProject.Data;
using ImageAfricaProject.Repository.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ImageAfricaProject.Repository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        //private DbContext dbContext;
        private ApplicationDbContext _dbContext;
        private Dictionary<Type, object> repos;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            if (repos == null)
            {
                repos = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repos.ContainsKey(type))
            {
                repos[type] = new GenericRepository<TEntity>(_dbContext);
            }

            return (IGenericRepository<TEntity>)repos[type];
        }

        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(obj: this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }

}
