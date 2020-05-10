using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Google.Apis.Auth;
using ImageAfricaProject.Data;
using ImageAfricaProject.Dto;
using ImageAfricaProject.Dto.auth;
using ImageAfricaProject.Entities;
using ImageAfricaProject.Repository.Generic;
using ImageAfricaProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Refit;

namespace ImageAfricaProject.Repository
{
    public class UserRepository: GenericBasicRepository<ApplicationUser>, IUserRepository
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

        public async Task<UserResponseFbDto> GetFacebookUser(string userId, string token)
        {
            try
            {
                return  await RestService
                    .For<IFacebookAutApi>("https://graph.facebook.com/v6.0")
                    .GetUserInfo(userId, token);

                
            }
            catch (ValidationApiException validationException)
            {
                // handle validation here by using validationException.Content,
                // which is type of ProblemDetails according to RFC 7807

                // If the response contains additional properties on the problem details,
                // they will be added to the validationException.Content.Extensions collection.
                Console.WriteLine(validationException.Message);
                return null;
            }
            catch (ApiException exception)
            {
                // other exception handling
                Console.WriteLine(exception.Message);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

            return null;
        }
        public async Task<List<UserLeaderBoardDto>> GetLast30DaysLeaderboard()
        {
            try
            {
                DateTime thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);
            var imageViews = from ImageView in _dbContext.ImageViews
                             join Images in _dbContext.Images
                             on ImageView.ImageId equals Images.Id
                             select new { ImageView.Id, ImageView.ImageId, UserId = Images.UserId, Images.CreationTime };
           
                var user = (from User in _dbContext.Users
                            join ImageView in imageViews
                            on User.Id equals ImageView.UserId
                            where ImageView.CreationTime > thirtyDaysAgo
                            let imageViewCount = imageViews.Count(i => i.UserId != null)
                            orderby imageViewCount
                            select new UserLeaderBoardDto
                            {
                                UserName = User.UserName,
                                FirstName = User.FirstName,
                                LastName = User.LastName,
                                Id = Convert.ToInt32(User.Id),
                                ImageViewCounts = imageViewCount,
                                Images = new List<object>()
                            }).Distinct().ToList();

                var images = (from Image in _dbContext.Images
                              join ImageView in imageViews
                              on Image.Id equals ImageView.ImageId
                              where ImageView.CreationTime > thirtyDaysAgo
                              let ImageViewCount = imageViews.Count(i => i.ImageId != 0)
                              orderby ImageViewCount
                              select new { Image.Name, Image.UserId, ImageViewCount, Image.ImageUrl, Image.Id }).Distinct().ToList();

                foreach (var image in images)
                {
                    UserLeaderBoardDto User = user.Where(a => a.Id.ToString() == image.UserId).FirstOrDefault();
                    var ul = User.Images;
                    ul.Add(image);
                };
                return user;
            }
            catch (Exception ex)
            {

                throw;
            }
          


        }
        public async Task<List<UserLeaderBoardDto>> GetAllTimeLeaderboard()
        {
            DateTime thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);
            var imageViews = from ImageView in _dbContext.ImageViews
                             join Images in _dbContext.Images
                             on ImageView.ImageId equals Images.Id
                             select new { ImageView.Id, ImageView.ImageId, UserId = Images.UserId, Images.CreationTime };

            var user = (from User in _dbContext.Users
                        join ImageView in imageViews
                        on User.Id equals ImageView.UserId
                        where ImageView.CreationTime > thirtyDaysAgo
                        let imageViewCount = imageViews.Count(i => i.UserId != null)
                        orderby imageViewCount
                        select new UserLeaderBoardDto
                        {
                            UserName = User.UserName,
                            FirstName = User.FirstName,
                            LastName = User.LastName,
                            Id = Convert.ToInt32(User.Id),
                            ImageViewCounts = imageViewCount,
                            Images = new List<object>()
                        }).Distinct().ToList();

            var images = (from Image in _dbContext.Images
                          join ImageView in imageViews
                          on Image.Id equals ImageView.ImageId
                          where ImageView.CreationTime > thirtyDaysAgo
                          let ImageViewCount = imageViews.Count(i => i.ImageId != 0)
                          orderby ImageViewCount
                          select new { Image.Name, Image.UserId, ImageViewCount, Image.ImageUrl, Image.Id }).Distinct().ToList();

            foreach (var image in images)
            {
                UserLeaderBoardDto User = user.Where(a => a.Id.ToString() == image.UserId).FirstOrDefault();
                var ul = User.Images;
                ul.Add(image);
            };
            return user;
        }
    }
}
