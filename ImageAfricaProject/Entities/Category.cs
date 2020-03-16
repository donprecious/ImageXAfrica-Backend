using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ImageAfricaProject.Data;
using ImageAfricaProject.Data.Interface;

namespace ImageAfricaProject.Entities
{
    public  class Category:  Entity, IFullAuditable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public string LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public string DeleterUserId { get; set; }
    }

 
}
