using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageAfricaProject.Data;
using ImageAfricaProject.Data.Interface;
using ImageAfricaProject.Dto.contentCollection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ImageAfricaProject.Entities
{
    [AutoMap(typeof(ContentCollectionDto))]
    public class ContentCollection : Entity, IFullAuditable
    {
     
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string CreatorUserId { get; set; }
        public int ImageId {get;set;}
        public Images Image { get; set; }

        public ContentCollection()
        {
            
        }
        public DateTime? LastModificationTime { get; set; }
        public string LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public string DeleterUserId { get; set; }
    }
}
