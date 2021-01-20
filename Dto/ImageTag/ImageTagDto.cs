using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageAfricaProject.Data;
using ImageAfricaProject.Dto.image;

namespace ImageAfricaProject.Dto.ImageTag
{
    [AutoMap(typeof(Entities.ImageTag))]
    public class ImageTagDto :EntityDto
    {
        public int ImageId {get;set;}
        public ImageDto Image { get;set; }
         
        public int TagId {get;set;}

      
        public TagDto Tag { get;set; }
    }
}
