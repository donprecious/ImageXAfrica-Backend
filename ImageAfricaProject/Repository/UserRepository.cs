using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Data;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Repository.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ImageAfricaProject.Repository
{
    public class UserRepository: GenericRepository<ApplicationUser>, IUserRepository
    {
        private UserManager<ApplicationUser> _userManager;


        public UserRepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager) : base(dbContext)
        {
            _userManager = userManager;
        }
    }
}
