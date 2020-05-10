using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ImageAfricaProject.Data;
using Microsoft.EntityFrameworkCore;

namespace ImageAfricaProject.Repository.Generic
{
    public interface IGenericRepository<TEntity>
        where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        IQueryable<TEntity> Query();
       Task<TEntity> Get(Expression<Func<TEntity, bool>> where);
        Task Create(TEntity entity);
        Task CreateMany(List<TEntity> entity);
        Task Update( TEntity entity);
        Task Delete(int id);
        Task Delete(TEntity entity);
        Task SoftDelete(TEntity entity);
        Task<bool> Save();
    }
}
