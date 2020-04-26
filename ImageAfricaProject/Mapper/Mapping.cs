using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageAfricaProject.Dto;
using ImageAfricaProject.Dto.category;
using ImageAfricaProject.Dto.challenge;
using ImageAfricaProject.Dto.image;
using ImageAfricaProject.Dto.ImageTag;
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
            CreateMap<UpdateUserDto, ApplicationUser>();
            CreateMap<ApplicationUser, UpdateUserDto>();
            CreateMap<CreateUserDto, ApplicationUser>();
            CreateMap<ApplicationUser, UserAuthDto>();

            CreateMap<Images, GetImageDto>();
            CreateMap<Images, ImageDto>();
            CreateMap<CreateImageDto, Images>();

            CreateMap<Category, CategoryDto>();

            CreateMap<ImageTag, ImageTagDto>();
         
            CreateMap<Tag, TagDto>();
            CreateMap<Tag, TagDto>();

            CreateMap<Challenge, GetChallengeDto>();
            CreateMap<CreateChallengeDto, Challenge>();
            CreateMap<Challenge, UpdateChallengeDto>();
            CreateMap<UpdateChallengeDto, Challenge>();
            CreateMap<UserChallengeDto, UserChallenge>();
        }
    }
}
