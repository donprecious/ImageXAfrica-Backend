using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAfricaProject.Data
{
    public class Entity
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Entity()
        {
            CreationTime = DateTime.UtcNow;
        }
    public DateTime CreationTime { get; set; }
    public string CreatorUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public  string LastModifierUserId { get; set; }
    public  bool IsDeleted { get; set; }
    public DateTime? DeletionTime { get; set; }
    public string DeleterUserId { get; set; }
    }
}
