using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ImageAfricaProject.Data;
using Microsoft.EntityFrameworkCore;

namespace ImageAfricaProject.Repository.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();

        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
                .FindAsync(id);
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            
           
            _dbContext.Set<TEntity>().Update(entity);
        }

        public async Task Delete(int id)
        {  
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }
          
        public async Task<bool> Save()
        {
            return await((DbContext)_dbContext).SaveChangesAsync(default(CancellationToken)) >= 0;
        }
    }
}
