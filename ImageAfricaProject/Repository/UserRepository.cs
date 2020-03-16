using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ImageAfricaProject.Data;
using ImageAfricaProject.Dto;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Repository.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ImageAfricaProject.Repository
{
    public class UserRepository: GenericRepository<ApplicationUser>, IUserRepository
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

      
        public UserRepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
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
    }
}
