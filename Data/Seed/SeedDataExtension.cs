using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageAfricaProject.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ImageAfricaProject.Data
{
  public static  class SeedDataExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var userId = Guid.NewGuid().ToString();
            var password = "user@gmail.com";
            var passwordHaser= new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser()
            {
                Email = "user@gmail.com",
                UserName = "user@gmail.com",
                Id = userId,
                
            };
            
            var passwordHash = passwordHaser.HashPassword(user, password);
            user.PasswordHash = passwordHash;

            modelBuilder.Entity<ApplicationUser>().HasData(new List<ApplicationUser>()
            {
                user
            });
            
            modelBuilder.Entity<Category>().HasData(new List<Category>()
            {

                new Category()
                {
                    Id = 1,
                    CreatorUserId = userId,
                    Name = "Birthday",

                },
                new Category()
                {
                    Id = 2,
                    CreatorUserId = userId,
                    Name = "Entertainment",

                },
                new Category()
                {
                    Id = 3,
                    CreatorUserId = userId,
                    Name = "Celebration",

                },
                new Category()
                {
                    Id = 4,
                    CreatorUserId = userId,
                    Name = "Wild Life",

                },
                new Category()
                {
                    Id = 5,
                    CreatorUserId = userId,
                    Name = "Animals",

                },
            });

            modelBuilder.Entity<Tag>().HasData(new List<Tag>()
            {
                new Tag()
                {
                    Id = 1,
                    Name = "Africa"
                },
                new Tag()
                {
                    Id = 2,
                    Name = "International"
                },
                new Tag()
                {
                    Id = 3,
                    Name = "Simple"
                },
                new Tag()
                {
                    Id = 4,
                    Name = "Simple"
                },
            });

            modelBuilder.Entity<Images>().HasData(new List<Images>()
            {
                new Images()
                {
                    Id = 1,
                    Name = "Woman Sitting on a Sofa Chair in a Room",
                    ImageUrl =
                        "https://images.pexels.com/photos/2774197/pexels-photo-2774197.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260",
                    CategoryId = 1,
                    UserId = userId
                },
                new Images()
                {
                    Id = 2,
                    Name = "Pretty Woman",
                    ImageUrl =
                        "https://images.pexels.com/photos/1990360/pexels-photo-1990360.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260",
                    CategoryId = 2,
                    UserId = userId
                }, new Images()
                {
                    Id = 3,
                    Name = "Far Lady Woman",
                    ImageUrl =
                        "https://images.pexels.com/photos/3115635/pexels-photo-3115635.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                    CategoryId = 3,
                    UserId = userId
                },
            });
            modelBuilder.Entity<ImageTag>().HasData(new List<ImageTag>()
            {
                new ImageTag()
                {
                    Id = 1,
                    ImageId = 1,
                    TagId = 1
                },
                new ImageTag()
                {
                    Id = 2,
                    ImageId = 1,
                    TagId = 3
                },
                new ImageTag()
                {
                    Id = 3,
                    ImageId = 1,
                    TagId = 4
                },
                new ImageTag()
                {
                    Id = 4,
                    ImageId = 2,
                    TagId = 1
                },
                new ImageTag()
                {
                    Id = 5,
                    ImageId = 2,
                    TagId = 4
                },
                new ImageTag()
                {
                    Id = 6,
                    ImageId = 3,
                    TagId = 2
                },
            });
        }
    }
}
