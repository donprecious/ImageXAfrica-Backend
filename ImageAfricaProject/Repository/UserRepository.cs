using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Google.Apis.Auth;
using ImageAfricaProject.Data;
using ImageAfricaProject.Dto;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Repository.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ImageAfricaProject.Repository
{
    public class UserRepository: GenericRepository<ApplicationUser>, IUserRepository
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
      
        public UserRepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(dbContext)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
        }

        public ApplicationUser CreateNewUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            var user = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
           return await _userManager.FindByNameAsync(user);
        }

        public async  Task<GoogleJsonWebSignature.Payload> ValidateGooglePayLoad(string tokenId)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings(){
                Audience = new string[] { _config.GetSection("Google:ClientId").Value } 
            };
            
           
            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenId, settings);
            return payload;
        }
    }
}
