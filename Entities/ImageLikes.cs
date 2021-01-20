using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Data;

namespace ImageAfricaProject.Entities
{
    public class ImageLike: Entity
    {
        public int ImageId {get;set;} 

        [ForeignKey("ImageId")]
        public Images Image { get; set; }

        public string UserId {get;set;} 

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
