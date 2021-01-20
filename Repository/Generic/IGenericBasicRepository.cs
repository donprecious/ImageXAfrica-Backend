using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ImageAfricaProject.Repository.Generic
{
    public interface IGenericBasicRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);
        DbSet<TEntity> Query();
        Task Create(TEntity entity);
        Task CreateMany(List<TEntity> entity);
        Task Update( TEntity entity);

        Task Delete(int id);
        Task<bool> Save();
    }
}
