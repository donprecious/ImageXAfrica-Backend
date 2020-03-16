using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using ImageAfricaProject.Data;
using ImageAfricaProject.Data.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ImageAfricaProject.Entities
{
    public class Images : Entity, IFullAuditable
    {
        public Images()
        {
         
        }

        public string ImageUrl {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public string Location {get;set;}
        public double GeoLat {get;set;}
        public double GeoLog {get;set;}
        public int CategoryId{get;set;}
        public string UserId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category {get;set;}

        [ForeignKey("UserId")]
        public ApplicationUser User{
            get;
            set;
        }
        
        public ICollection<ImageTag> ImageTag { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public string LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public string DeleterUserId { get; set; }
    }
}
