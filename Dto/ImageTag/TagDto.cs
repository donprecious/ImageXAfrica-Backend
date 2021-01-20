using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageAfricaProject.Data;
using ImageAfricaProject.Entities;

namespace ImageAfricaProject.Dto.ImageTag
{
    [AutoMap(typeof(Tag))]
    public class TagDto : EntityDto
    {
        public string Name {get;set;}
        public string Description {get;set;} 

    }
}
