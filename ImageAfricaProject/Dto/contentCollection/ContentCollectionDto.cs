using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageAfricaProject.Data;
using ImageAfricaProject.Dto.image;
using ImageAfricaProject.Entities;

namespace ImageAfricaProject.Dto.contentCollection
{
    [AutoMap(typeof(ContentCollection))]
    public class ContentCollectionDto: EntityDto
    {
        [Required( ErrorMessage = "User id not present")]
        public string UserId { get; set; }
        public UserDto User{get;set;}

        [Required( ErrorMessage = "Image Not Present")]

        public int ImageId {get;set;}
        public ImageDto Image{get;set;}
    }
}
