using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageAfricaProject.Dto;
using ImageAfricaProject.Entities;

namespace ImageAfricaProject.Mapper
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            // create mapping here 
          //  CreateMap<source, destination>()
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>();
            CreateMap<CreateUserDto, ApplicationUser>();
            CreateMap<ApplicationUser, UserAuthDto>();
        }
    }
}
