using ImageAfricaProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAfricaProject.Repository
{
    public interface IChallengeRepository
    {
        Task<Challenge> GetChallenge(int id);
        Task<UserChallenge> GetUserChallenge(int challengeId, string userId);
        Task<IEnumerable<Challenge>> GetActiveChallenges();
        Task<IEnumerable<Challenge>> GetExpiredChallenges();
        Task Create(Challenge challenge);
        void DeleteChallenge(Challenge challenge);
        Task JoinChallenge(UserChallenge userChallenge);
        Task LeaveChallenge(UserChallenge userChallenge);
        Task<bool> Save();
    }
}
