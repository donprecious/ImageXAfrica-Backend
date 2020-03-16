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
    }
}
