using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Dto.category;
using ImageAfricaProject.Dto.ImageTag;
using ImageAfricaProject.Entities;

namespace ImageAfricaProject.Dto.image
{
    public class GetImageDto
    {
        public int Id { get; set; }
        public string ImageUrl {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public string Location {get;set;}
        public double GeoLat {get;set;}
        public double GeoLog {get;set;}
        public int CategoryId{get;set;}
        public string UserId { get; set; }
        public string FileType { get; set; }
        public UserDto User
        {
            get;
            set;
        }
        public  CategoryDto Category { get; set; }

        public List<ImageTagDto> ImageTag { get; set; }
    }
}
