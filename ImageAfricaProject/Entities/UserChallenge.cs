using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAfricaProject.Entities
{
    public class UserChallenge
    {
        public int Id { get; set; }
        public int ChallengeId { get; set; }
        [ForeignKey("ChallengeId")]
        public Challenge Challenge { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
