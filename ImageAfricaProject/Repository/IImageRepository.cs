using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Repository.Generic;

namespace ImageAfricaProject.Repository
{
  public  interface IImageRepository : IGenericRepository<Images>
  {
      Task<ImageView> AddImageViews(ImageView view);
      
      Task<ImageLike> AddImageLike(ImageLike like);
      IQueryable<ImageLike> QueryLikes();
      IQueryable<ImageView> QueryViews();
  }
}
