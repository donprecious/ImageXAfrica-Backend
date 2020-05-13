using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ImageAfricaProject.Data;
using Microsoft.EntityFrameworkCore;

namespace ImageAfricaProject.Repository.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : Entity
    {
        public readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking()
                .Where(a=>a.IsDeleted != true)
                .OrderByDescending(a=>a.CreationTime);

        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
                .FindAsync(id);
        }
        public  IQueryable<TEntity> Query()
        {
            return _dbContext.Set<TEntity>()
                .Where(a=>a.IsDeleted != true)
                .OrderByDescending(a =>a.CreationTime);

        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> where)
        {
            return await _dbContext.Set<TEntity>()
                .Where(a=>a.IsDeleted != true)
                .FirstOrDefaultAsync(where);
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }
        public async Task CreateMany(List<TEntity> entity)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entity);
        }
        public async Task Update(TEntity entity)
        {
            entity.LastModificationTime = DateTime.UtcNow;

            _dbContext.Set<TEntity>().Update(entity);
        }

        public async Task Delete(int id)
        {  

            var entity = await GetById(id);
          

            _dbContext.Set<TEntity>().Remove(entity);
        }
        public async Task Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
        public async Task SoftDelete(TEntity entity)
        {
            entity.DeletionTime = DateTime.UtcNow;
            entity.LastModificationTime = DateTime.UtcNow;
            entity.IsDeleted = true;
            _dbContext.Set<TEntity>().Update(entity);
        }
          
        public async Task<bool> Save()
        {
            return await ((DbContext)_dbContext).SaveChangesAsync(default(CancellationToken)) >= 0; 
        }
    }
}
