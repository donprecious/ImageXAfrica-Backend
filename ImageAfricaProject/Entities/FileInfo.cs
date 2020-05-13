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
        public Images Image { get; set; }
        public string Artist { get; set; }
        public  string Model { get; set; }
        public  string Software { get; set; }
        public  string Width { get; set; }
        public  string Height { get; set; }
        public  string Duration { get; set; }
        public  string Genre { get; set; }
        public  string FileSize { get; set; }

    }
}
