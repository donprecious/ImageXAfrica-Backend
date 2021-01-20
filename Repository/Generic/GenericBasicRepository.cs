using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ImageAfricaProject.Data;
using Microsoft.EntityFrameworkCore;

namespace ImageAfricaProject.Repository.Generic
{
    public class GenericBasicRepository<TEntity> : IGenericBasicRepository<TEntity>
        where TEntity : class
    {
        public readonly ApplicationDbContext _dbContext;

        public GenericBasicRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();

        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
                .FindAsync(id);
        }
        public  DbSet<TEntity> Query()
        {
            return _dbContext.Set<TEntity>();

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
