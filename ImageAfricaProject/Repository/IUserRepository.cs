﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Dto;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Repository.Generic;

namespace ImageAfricaProject.Repository
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        ApplicationUser CreateNewUser(UserDto user);
        Task<ApplicationUser> GetCurrentUserAsync();
    }
}
