using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ImageAfricaProject.Data;
using ImageAfricaProject.Data.Interface;

namespace ImageAfricaProject.Entities
{
    public class Tag : Entity 
    {
        public Tag()
        {
 
        }
        public string Name {get;set;}
        public string Description {get;set;}

    }
}
