using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Data;

namespace ImageAfricaProject.Entities
{
    public class Color: Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class ImageColor : Entity
    {
        public int ImageId { get; set; }

        [ForeignKey("ImageId")]
        public Images Image { get;set; }
        public string Level { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }

}
