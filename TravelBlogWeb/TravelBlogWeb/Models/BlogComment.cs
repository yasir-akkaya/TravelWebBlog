using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlogWeb.Entity.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelBlogWeb.Entity.Data;

namespace TravelBlogWeb.Models
{
    public class BlogComment
    {
       
        public int Id { get; set; }

        public int UserId { get; set; }

        public int BlogPostId { get; set; }

        [Required]
        public string Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; }
        public virtual User User { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}