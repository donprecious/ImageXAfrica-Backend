using System;
using System.Collections.Generic;
using System.Text;
using ImageAfricaProject.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImageAfricaProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<ImageTag> ImageTags { get; set; }
        public virtual DbSet<ContentCollection> ContentCollections { get; set; }
        public virtual DbSet<ImageView> ImageViews { get; set; }
        public virtual DbSet<ImageLike> ImageLikes { get; set; }
        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<UserChallenge> UserChallenges { get; set; } 

        public virtual DbSet<FileInfo> FileInfos { get; set; }
        public virtual DbSet<ImageColor> ImageColors { get; set; }
        public virtual DbSet<Color> Colors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {

            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<Images>().HasOne(b => b.Category);
            modelBuilder.Entity<Images>().HasOne(b => b.User);
            modelBuilder.Entity<Images>().HasMany(a => a.ImageTag);

            modelBuilder.Entity<ImageTag>().HasOne(b => b.Tag);
            modelBuilder.Entity<ImageTag>().HasOne(b => b.Image);

            modelBuilder.Entity<ContentCollection>().HasOne(a => a.User);
            modelBuilder.Entity<ContentCollection>().HasOne(a => a.Image);

            modelBuilder.Entity<ImageView>().HasOne(a => a.Image);
            modelBuilder.Entity<ImageView>().HasOne(a => a.Image);
            modelBuilder.Entity<FileInfo>().HasOne(a => a.Image);
           
            modelBuilder.Entity<Color>();
            modelBuilder.Entity<ImageColor>().HasOne(a => a.Image);
            modelBuilder.Entity<ImageColor>().HasOne(a => a.Color);


            //comment if app is first run 
            //modelBuilder.Seed();
        }

       
    }
}
