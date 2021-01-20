using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Data;

namespace ImageAfricaProject.Dto.color
{
    public class ColorDto: EntityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
