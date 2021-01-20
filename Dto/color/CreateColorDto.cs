using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageAfricaProject.Data;

namespace ImageAfricaProject.Dto.color
{
    public class CreateColorDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        [IgnoreMap]
        public string Level { get; set; }
    }
}
