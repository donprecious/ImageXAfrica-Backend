using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAfricaProject.Dto
{
    public class UserLeaderBoardDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public int ImageViewCounts { get; set; }
        public List<Object> Images { get; set; }
    }
}
