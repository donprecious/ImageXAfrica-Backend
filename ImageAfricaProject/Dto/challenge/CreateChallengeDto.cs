using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAfricaProject.Dto.challenge
{
    public class CreateChallengeDto
    {
        public CreateChallengeDto()
        {
            CreationTime = DateTime.UtcNow;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TipsAndConditions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Prize { get; set; }
        public string OrganizerName { get; set; }
        public string OrganizerUrl { get; set; }
        public DateTime CreationTime { get; set; }
        
    }
}
