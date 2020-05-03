using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Data;

namespace ImageAfricaProject.Entities
{
    public class FileInfo: Entity
    {
        public int ImageId { get; set; }
        public string Artist { get; set; }
    }
}
