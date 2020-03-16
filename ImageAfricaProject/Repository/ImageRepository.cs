using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Data;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Repository.Generic;

namespace ImageAfricaProject.Repository
{
    public class ImageRepository :  GenericRepository<Images>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<ImageView> AddImageViews(ImageView view)
        {
          await  _dbContext.ImageViews.AddAsync(view);
          return view;
        }

        public async Task<ImageLike> AddImageLike(ImageLike like)
        {
            await _dbContext.ImageLikes.AddAsync(like);
            return like;
        }

        public IQueryable<ImageLike> QueryLikes()
        {
            return _dbContext.ImageLikes.AsQueryable();
        }
        public IQueryable<ImageView> QueryViews()
        {
            return _dbContext.ImageViews.AsQueryable();
        }
    }
}
