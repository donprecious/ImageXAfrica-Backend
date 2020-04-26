using ImageAfricaProject.Data;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAfricaProject.Repository
{
    public class ChallengeRepository: GenericRepository<Challenge>, IChallengeRepository
    {
        public ChallengeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<Challenge> GetChallenge(int id)
        {
            return Query().Where(a => a.Id == id && a.IsDeleted == false).FirstOrDefault();
        }
        public async Task<UserChallenge> GetUserChallenge(int challengeId, string userId)
        {
            return _dbContext.UserChallenges.Where(a => a.UserId == userId && a.ChallengeId == challengeId).FirstOrDefault();
        }
        public async Task<IEnumerable<Challenge>> GetActiveChallenges()
        {
            var presentDate = DateTime.Now;
            return Query().Where(a => a.EndDate > presentDate && a.IsDeleted == false).ToList();
        }
        public async Task<IEnumerable<Challenge>> GetExpiredChallenges()
        {
            var presentDate = DateTime.Now;
            return Query().Where(a => a.EndDate < presentDate && a.IsDeleted == false).ToList();
        }
        public async void DeleteChallenge(Challenge challenge)
        {
            challenge.IsDeleted = true;
        }
        public async Task JoinChallenge(UserChallenge userChallenge)
        {
            await _dbContext.UserChallenges.AddAsync(userChallenge);
        }
        public async Task LeaveChallenge(UserChallenge userChallenge)
        {
            _dbContext.UserChallenges.Remove(userChallenge);
        }
    }
}
