using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAfricaProject.Data.Interface
{
    interface IFullAuditable
    {
        string CreatorUserId { get; set; }
        DateTime? LastModificationTime { get; set; }
        string LastModifierUserId { get; set; }
        bool IsDeleted { get; set; }
        DateTime? DeletionTime { get; set; }
        string DeleterUserId { get; set; }
    }
}
