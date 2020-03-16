using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageAfricaProject.Data;
using ImageAfricaProject.Data.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace ImageAfricaProject.Entities
{
  public  class ImageTag: Entity, IFullAuditable
    {
        public ImageTag()
        {
          
        } 

        public int ImageId {get;set;}

        [ForeignKey("ImageId")]
        public Images Image { get;set; }
         
        public int TagId {get;set;}

        [ForeignKey("TagId")]
        public Tag Tag { get;set; }

   
        public string CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public string LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public string DeleterUserId { get; set; }
    }
}
