using ImageAfricaProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAfricaProject.Dto.challenge
{
    public class GetChallengeDto:EntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TipsAndConditions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Prize { get; set; }
        public int FirstWinnerImageId { get; set; }
        public int SecondWinnerImageId { get; set; }
        public string OrganizerName { get; set; }
        public string OrganizerUrl { get; set; }
    }
}
