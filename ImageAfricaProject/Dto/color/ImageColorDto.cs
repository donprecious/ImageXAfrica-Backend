using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Dto.image;

namespace ImageAfricaProject.Dto.color
{
    public class ImageColorDto
    {
        public int ImageId { get; set; }
        public ImageDto Image { get;set; }

        public string Level { get; set; }
        public int ColorId { get; set; }
        public ColorDto Color { get; set; }
    }
}
