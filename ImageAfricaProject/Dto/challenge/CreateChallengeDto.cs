using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ImageAfricaProject.Dto.challenge
{
    public class CreateChallengeDto
    {
        [Required(ErrorMessage = "Title Required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string TipsAndConditions { get; set; }
        [Required(ErrorMessage = "Start Date Required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date Required")]
        public DateTime EndDate { get; set; }
        public string Prize { get; set; }
        [Required(ErrorMessage = "Organizer's Name Required")]
        public string OrganizerName { get; set; }
        public string OrganizerUrl { get; set; }
        public DateTime CreationTime { get; set; }
        
    }
}
