using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageAfricaProject.Dto.color;
using ImageAfricaProject.Dto.fileInfo;
using ImageAfricaProject.Entities;
using FileInfo = System.IO.FileInfo;

namespace ImageAfricaProject.Dto.image
{
    [AutoMap(typeof(Images))]
    public class CreateImageDto
    {
      
        [Required (ErrorMessage = "Image or Image Url Required")]
        public string ImageUrl {get;set;}
        [Required(ErrorMessage = "Title Required")]
        public string Name {get;set;}
        public string Description {get;set;}
        public string Location {get;set;}
        public double GeoLat {get;set;}
        public double GeoLog {get;set;}
        [Required (ErrorMessage = "Category Required")]
        public int CategoryId{get;set;}
        public string UserId { get; set; }
      
        public string FileType { get; set; }
        public List<string> Tag { get; set; } 

        [IgnoreMap]
        public List<CreateColorDto> Colors { get; set; }

        [IgnoreMap]
        public CreateFileInfoDto FileInfo { get; set; }

        
    }
}
