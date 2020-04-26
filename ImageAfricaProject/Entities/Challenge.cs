using ImageAfricaProject.Data;
using ImageAfricaProject.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAfricaProject.Entities
{
    public class Challenge: Entity, IFullAuditable
    {
        public string Name { get; set; }
        public string  Description { get; set; }
        public string TipsAndConditions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Prize { get; set; }
        public int FirstWinnerImageId { get; set; }
        public int SecondWinnerImageId { get; set; }
        public string OrganizerName { get; set; }
        public string OrganizerUrl { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public string LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public string DeleterUserId { get; set; }
    }
}
