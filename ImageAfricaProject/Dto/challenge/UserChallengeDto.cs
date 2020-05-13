using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAfricaProject.Dto.challenge
{
    public class UserChallengeDto
    {
        public UserChallengeDto()
        {
            JoinedAt = DateTime.UtcNow;
        }
        public int ChallengeId { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
