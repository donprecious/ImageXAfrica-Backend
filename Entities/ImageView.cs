using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Data;

namespace ImageAfricaProject.Entities
{
    public class ImageView: Entity
    {
        public int ImageId {get;set;} 

        [ForeignKey("ImageId")]
        public Images Image { get; set; }
    }
}
