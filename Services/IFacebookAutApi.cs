using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageAfricaProject.Dto.auth;
using Refit;

namespace ImageAfricaProject.Services
{
   public interface IFacebookAutApi
   {
       [Get("/{userId}/?fields=email,first_name,last_name,picture.width(320)&access_token={token}")]
       Task<UserResponseFbDto> GetUserInfo(string userId, string token);
   }
}
