using ImageAfricaProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAfricaProject.Dto
{
    public class UserLeaderBoardDto: EntityDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ImageViewCounts { get; set; }
        public List<Object> Images { get; set; }
    }
}
