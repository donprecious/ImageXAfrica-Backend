using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageAfricaProject.Entities;

namespace ImageAfricaProject.Dto.image
{
    [AutoMap(typeof(Images))]
    public class ImageDto
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
        public bool IsVideo { get; set; }
        public string FileType { get; set; }
    
    }
}
