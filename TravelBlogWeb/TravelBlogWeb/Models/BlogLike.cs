using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlogWeb.Entity.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TravelBlogWeb.Models
{
    public class BlogLike
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int BlogPostId { get; set; }

        public virtual User User { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}