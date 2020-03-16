using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Data;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Repository.Generic;

namespace ImageAfricaProject.Repository
{
    public class ContentCollectionRepository :  GenericRepository<ContentCollection>, IContentCollectionRepository
    {
        public ContentCollectionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
