using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Data;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Repository.Generic;

namespace ImageAfricaProject.Repository
{
    public class ImageTagRepository :  GenericRepository<ImageTag>,  IImageTagRepository
    {
        public ImageTagRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
