using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth;
using ImageAfricaProject.Dto;
using ImageAfricaProject.Dto.auth;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Repository.Generic;

namespace ImageAfricaProject.Repository
{
    public interface IUserRepository : IGenericBasicRepository<ApplicationUser>
    {
        ApplicationUser CreateNewUser(UserDto user);
        Task<ApplicationUser> GetCurrentUserAsync();
        Task<GoogleJsonWebSignature.Payload> ValidateGooglePayLoad(string tokenId);
        Task<UserResponseFbDto> GetFacebookUser(string userId, string token);
        Task<List<UserLeaderBoardDto>> GetLast30DaysLeaderboard();
        Task<List<UserLeaderBoardDto>> GetAllTimeLeaderboard();
    }
}
